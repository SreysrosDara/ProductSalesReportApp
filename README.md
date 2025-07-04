# ProductSalesReportApp
A WinForms application using DevExpress to generate sales reports filtered by date.

## 📋 Features
- Filter product sales by date range
- Generate grouped report by Product Code
- View and export to PDF
- Show totals per product and grand total

## 🛠 Setup Instructions

1. **Clone the repository**
git clone https://github.com/SreysrosDara/ProductSalesReportApp.git

2. **Open the Solution**
- Open `ProductSalesReportApp.sln` in Visual Studio

3. **Setup Database**
- Run `create_and_seed.sql` on your SQL Server to create the `ProductSales` table and insert sample data

> ⚠️ If you don't have SQL Server, you can use **(localdb)\MSSQLLocalDB** with the same script.

4. **Connection String**
Update the `connectionString` inside `ProductSaleReport.cs` if needed:
  @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductSalesDb;Integrated Security=True;";

6.**Build and Run**
- Run the app in Visual Studio
- Select a start and end date
- Click "Generate Report"
