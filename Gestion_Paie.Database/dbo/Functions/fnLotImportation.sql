

Create Function [fnLotImportation]
(
)


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Returns Table

As

Return
(
Select TOP 100 PERCENT
 [lo_code_canton]
,[lo_rang]
,[lo_code]
,[lo_super_tot]
,[lo_super_boisee]
,[lo_super_contin]
,[lo_code_fournisseur]
,[lo_code_muni]
,[lo_code_prop]
,[lo_code_cont]
,[lo_date]
,[lo_code_deux]
,[Traite]
,[Valide]
,[Raison]

From [dbo].[LotImportation]

)


