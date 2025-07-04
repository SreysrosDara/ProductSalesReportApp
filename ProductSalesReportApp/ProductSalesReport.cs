using System;
using System.Windows.Forms;
using ProductSalesReportApp.Services;
using ProductSalesReportApp.Reports;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace ProductSalesReportApp
{
    public partial class ProductSalesReport : Form
    {
        private static readonly string connectionString =
            @"Server=DESKTOP-ABBY;Database=ProductSalesDb;Integrated Security=True;TrustServerCertificate=True;";

        public ProductSalesReport()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var service = new SalesService(connectionString);
            var sales = service.GetSales(dtpStart.Value, dtpEnd.Value);

            if (sales.Count == 0)
            {
                MessageBox.Show("No data found.");
                return;
            }
            
            var report = new SalesReport();
            report.DataSource = sales;
            report.Parameters["StartDate"].Value = dtpStart.Value;
            report.Parameters["EndDate"].Value = dtpEnd.Value;
            report.Parameters["StartDate"].Visible = false;
            report.Parameters["EndDate"].Visible = false;
            report.CreateDocument();

            new ReportPrintTool(report).ShowPreview();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            var service = new SalesService(connectionString);
            var sales = service.GetSales(dtpStart.Value, dtpEnd.Value);

            if (sales.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            var report = new SalesReport();
            report.DataSource = sales;
            report.Parameters["StartDate"].Value = dtpStart.Value;
            report.Parameters["EndDate"].Value = dtpEnd.Value;
            report.Parameters["StartDate"].Visible = false;
            report.Parameters["EndDate"].Visible = false;
            report.CreateDocument();

            string filePath = $"ProductSalesReport_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
            report.ExportToPdf(filePath);
            MessageBox.Show($"Exported to {filePath}");
        }
    }
}
