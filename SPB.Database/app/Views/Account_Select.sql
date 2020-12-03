
CREATE VIEW [app].[Account_Select]
AS
SELECT
	acc.ID, 
	acc.CID, 
	comp.Name [CID_Text],
	acc.Email, 
	acc.Password,
	acc.RoleLUID, 
	meta.Description [RoleLUID_Text],
	meta.Code [roleMask],
	CAST(CASE WHEN acc.RoleLUID = app.Role_Support() THEN 1 ELSE 0 END as bit) [IsSupport],
	acc.ResetGuid, 
	acc.ResetExpiry, 
	acc.LastActivity, 
	acc.IsAdminReset, 
	acc.FirstName, 
	acc.LastName, 
	acc.Comment, 
	acc.Archive, 
	acc.Created, 
	acc.Updated, 
	acc.UpdatedBy, 
	acc2.Email [By]
FROM app.Account acc
INNER JOIN app.Company comp ON acc.CID = comp.ID 
INNER JOIN app.PermMeta meta ON acc.RoleLUID = meta.ID
INNER JOIN app.Account acc2 ON acc2.ID = acc.UpdatedBy
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'app', @level1type = N'VIEW', @level1name = N'Account_Select';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[26] 4[45] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Account (app)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 238
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Company (app)"
            Begin Extent = 
               Top = 99
               Left = 282
               Bottom = 229
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PermMeta (app)"
            Begin Extent = 
               Top = 19
               Left = 539
               Bottom = 149
               Right = 709
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1740
         Alias = 900
         Table = 1965
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'app', @level1type = N'VIEW', @level1name = N'Account_Select';

