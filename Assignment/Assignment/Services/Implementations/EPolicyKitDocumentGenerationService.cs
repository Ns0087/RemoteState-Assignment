using Assignment.DAL.Repositories.Implementations;
using Assignment.DAL.Repositories.Interfaces;
using Assignment.Models.RequestViewModels;
using Assignment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PuppeteerSharp.Media;
using PuppeteerSharp;
using Assignment.DAL.Entities;

namespace Assignment.Services.Implementations
{
    public class EPolicyKitDocumentGenerationService : IEPolicyKitDocumentGenerationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly IDocumentRepository _documentRepository;

        public EPolicyKitDocumentGenerationService(IServiceProvider serviceProvider)
        {
            _userRepository = serviceProvider.GetRequiredService<IUserRepository>();
            _templateRepository = serviceProvider.GetRequiredService<ITemplateRepository>();
            _documentRepository = serviceProvider.GetRequiredService<IDocumentRepository>();
        }

        public async Task<int> EPolicyKitDocumentGenerationServiceAsync(DetailsModel details)
        {

            var user = await _userRepository.GetUserByDetailsAsync(details);
            if(user != null)
            {
                var template = await _templateRepository.GetHtmlTemplateByCreatedUserAsync(Convert.ToString(user.Id));
                var content = ContentSetter(template, user);

                var document =  await CreateDocument(content, user);
                

                return await AddDocument(document);
            }

            return 0;
        }

        private static async Task<byte[]> HtmlToPdf(string html)
        {
            await new BrowserFetcher().DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            await using var page = await browser.NewPageAsync();
            await page.EmulateMediaTypeAsync(MediaType.Screen);
            await page.SetContentAsync(html);
            var pdfContent = await page.PdfDataAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true
            });

            return pdfContent;
        }

        private static string ContentSetter(HtmlTemplate template, User user)
        {
            string content = null;
            if (template != null && template.Content != null)
            {
                content = template.Content;
                content = content.Replace("{{Name}}", user.Name);
                content = content.Replace("{{Age}}", Convert.ToString(user.Age));
                content = content.Replace("{{Salary}}", Convert.ToString(user.Salary));
                content = content.Replace("{{Occupation}}", user.Occupation);
                content = content.Replace("{{ProductCode}}", user.ProductCode);
                content = content.Replace("{{PolicyExpiryDate}}", Convert.ToString(user.PolicyExpiryDate));

                return content;
            }

            return content;

        }

        private static async Task<Document> CreateDocument(string content, User user)
        {
            if(content != null)
            {
                Document document = new Document()
                {
                    ObjectCode = $"{user.PolicyNumber}-{user.ProductCode}",
                    ReferenceType = "Policy",
                    RefernceNumber = user.PolicyNumber,
                    Content = await HtmlToPdf(content),
                    Filename = $"{user.PolicyNumber}" + DateTime.Now.ToString(),
                    FileExtension = ".pdf",
                    LanguageCode = "km-KH",
                    CreatedUser = Convert.ToString(user.Id),
                    CreatedDateTime = DateTime.Now,
                    IsDeleted = false
                };

                return document;
            }
            
            return new Document();
        }

        private async Task<int> AddDocument(Document document)
        {
            if (document != null)
            {
                var doc = await _documentRepository.GetDocumentByObjectCode(document.ObjectCode);
                if (doc != null)
                {
                    await _documentRepository.SoftDeleteDocument(doc);
                    return await _documentRepository.AddDocument(document);
                }
                else
                {
                    return await _documentRepository.AddDocument(document);
                }
            }
            return 0;
        }


    }
}
