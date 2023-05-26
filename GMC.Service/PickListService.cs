using GMC.Core;
using GMC.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class PickListService : IPickListService
    {
        private readonly IPickListRepository pickListRepository;
        public PickListService(IPickListRepository pickListRepository)
        {
            this.pickListRepository = pickListRepository;

        }

        public Task<PickList> CreatePickListAsync(PickList pickList)
        {
            return pickListRepository.CreatePickListAsync(pickList);
        }

        public Task<bool> DeletePickListAsync(int pickListId)
        {
            return pickListRepository.DeletePickListAsync(pickListId);
        }

        public PickList GetPickList(int pickListId)
        {
            return pickListRepository.GetPickList(pickListId);
        }

        public Task<PickList> GetPickListAsync(int pickListId)
        {
            return pickListRepository.GetPickListAsync(pickListId);
        }

        public List<PickList> GetPickLists()
        {
            return pickListRepository.GetPickLists();
        }

        public Task<List<PickListDTO>> GetPickListsAsync()
        {
            return pickListRepository.GetPickListsAsync();
        }

        public Task<PickList> UpdatePickListAsync(PickList pickList)
        {
            return pickListRepository.UpdatePickListAsync(pickList);
        }
        public Task<PickList> UpdatePickListNBUSAsync(PickList pickList)
        {
            return pickListRepository.UpdatePickListNBUSAsync(pickList);
        }
        public async Task<string> GeneratePickListReportAsync()
        {
            // Get all PickLists
            var pickLists = await pickListRepository.GetPickListsAsync();

            // Group PickLists by Status Code
            var pickListsByStatus = pickLists.GroupBy(pl => pl.Code)
                                             .ToDictionary(g => g.Key, g => g.ToList());

            // Prepare the PDF document
            using (var memoryStream = new MemoryStream())
            {
                using (var document = new Document())
                {
                    PdfWriter.GetInstance(document, memoryStream);
                    document.Open();

                    // Add logo
                    string imageURL = Path.Combine(Environment.CurrentDirectory, "wwwroot/images/logo.png");
                    Image logo = Image.GetInstance(imageURL);
                    logo.Alignment = Image.ALIGN_LEFT;
                    logo.ScaleAbsolute(150, 75); // Resize the image
                    logo.SetAbsolutePosition(36, PageSize.A4.Height - 100); // Set position of image
                    document.Add(logo);

                    // 5 line breaks after the logo
                    Paragraph logoSpace = new Paragraph(new string('\n', 4));
                    document.Add(logoSpace);

                    // Add title
                    Font titleFont = FontFactory.GetFont("Arial", 24, Font.BOLD, new BaseColor(39, 44, 74));
                    Paragraph title = new Paragraph("Report", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);

                    // 3 line breaks after the title
                    Paragraph titleSpace = new Paragraph(new string('\n', 3));
                    document.Add(titleSpace);

                    // Go through each group of PickLists
                    // Go through each group of PickLists
                    // Go through each group of PickLists
                    foreach (var group in pickListsByStatus)
                    {
                        // Add table for the group
                        var table = new PdfPTable(5); // 5 columns
                        table.DefaultCell.Border = Rectangle.BOX; // Borders for all cells

                        // Add group title as the first row in the table
                        Font groupTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD, new BaseColor(149, 220, 222));
                        PdfPCell groupTitleCell = new PdfPCell(new Phrase($"PickList {group.Key}", groupTitleFont));
                        groupTitleCell.Colspan = 5; // Span across all 5 columns
                        groupTitleCell.Border = Rectangle.BOTTOM_BORDER; // Only bottom border for this cell
                        table.AddCell(groupTitleCell);

                        // Create a PdfPCell to serve as space
                        PdfPCell spaceCell = new PdfPCell();
                        spaceCell.Border = PdfPCell.NO_BORDER;
                        spaceCell.FixedHeight = 20; // Adjust this value as needed
                        spaceCell.Colspan = 5; // Span across all columns
                        table.AddCell(spaceCell);

                        // Add column names
                        table.AddCell("NumPicklist");
                        table.AddCell("Magasin");
                        table.AddCell("NbUSServi");
                        table.AddCell("NbUSRecept");
                        table.AddCell("CreerPar");

                        // Add a row to the table for each PickList in the group
                        foreach (var pickList in group.Value)
                        {
                            table.AddCell(pickList.NumPickList);
                            table.AddCell(pickList.Magasin);
                            table.AddCell(pickList.NbUSServi.ToString());
                            table.AddCell(pickList.NbUSRecept.ToString());
                            table.AddCell(pickList.CreerPar);
                        }

                        document.Add(table);
                    }



                    document.Close();
                }

                // Convert MemoryStream to byte array, then to base64
                var pdfBytes = memoryStream.ToArray();
                var pdfBase64 = Convert.ToBase64String(pdfBytes);

                // Return the PDF in base64
                return pdfBase64;
            }
        }






    }
}
