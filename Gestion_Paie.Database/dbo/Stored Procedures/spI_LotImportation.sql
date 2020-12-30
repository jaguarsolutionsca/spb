

CREATE Procedure [spI_LotImportation]

-- Inserts a new record in [LotImportation] table
(
  @lo_code_canton [varchar](6) = Null  -- for [LotImportation].[lo_code_canton] column
, @lo_rang [varchar](25) = Null  -- for [LotImportation].[lo_rang] column
, @lo_code [varchar](6) = Null  -- for [LotImportation].[lo_code] column
, @lo_super_tot [varchar](50) = Null  -- for [LotImportation].[lo_super_tot] column
, @lo_super_boisee [varchar](50) = Null  -- for [LotImportation].[lo_super_boisee] column
, @lo_super_contin [varchar](50) = Null  -- for [LotImportation].[lo_super_contin] column
, @lo_code_fournisseur [varchar](6) = Null  -- for [LotImportation].[lo_code_fournisseur] column
, @lo_code_muni [varchar](6) = Null  -- for [LotImportation].[lo_code_muni] column
, @lo_code_prop [varchar](6) = Null  -- for [LotImportation].[lo_code_prop] column
, @lo_code_cont [varchar](6) = Null  -- for [LotImportation].[lo_code_cont] column
, @lo_date [varchar](50) = Null  -- for [LotImportation].[lo_date] column
, @lo_code_deux [varchar](6) = Null  -- for [LotImportation].[lo_code_deux] column
, @Traite [bit] = Null  -- for [LotImportation].[Traite] column
, @Valide [bit] = Null  -- for [LotImportation].[Valide] column
, @Raison [varchar](2000) = Null  -- for [LotImportation].[Raison] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

Insert Into [dbo].[LotImportation]
(
	  [lo_code_canton]
	, [lo_rang]
	, [lo_code]
	, [lo_super_tot]
	, [lo_super_boisee]
	, [lo_super_contin]
	, [lo_code_fournisseur]
	, [lo_code_muni]
	, [lo_code_prop]
	, [lo_code_cont]
	, [lo_date]
	, [lo_code_deux]
	, [Traite]
	, [Valide]
	, [Raison]
)

Values
(
	  @lo_code_canton
	, @lo_rang
	, @lo_code
	, @lo_super_tot
	, @lo_super_boisee
	, @lo_super_contin
	, @lo_code_fournisseur
	, @lo_code_muni
	, @lo_code_prop
	, @lo_code_cont
	, @lo_date
	, @lo_code_deux
	, @Traite
	, @Valide
	, @Raison
)

Set NoCount Off

Return(0)


