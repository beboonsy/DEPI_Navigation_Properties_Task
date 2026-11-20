# Creating real SSMS Database Diagram screenshots

1. Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance.
2. Open one file from `SQL_Scripts` using File > Open > File.
3. Execute the script (F5). Repeat for the other two scripts.
4. In Object Explorer, expand Databases > the database you created > Database Diagrams.
5. Right-click Database Diagrams > New Database Diagram.
6. If SSMS asks to install diagram support objects, choose Yes.
7. Add all tables shown in the Add Table window, then click Close.
8. Arrange the tables so all relationship lines are visible.
9. Take a screenshot using Win + Shift + S and save it as PNG.
10. Repeat for all three databases.

Expected databases:
- DEPI_ECommerceDB
- DEPI_LibraryDB
- DEPI_HealthCareDB

The scripts create real SQL Server tables, primary keys, foreign keys, and join tables. The screenshot must be captured from your own SSMS after executing them.
