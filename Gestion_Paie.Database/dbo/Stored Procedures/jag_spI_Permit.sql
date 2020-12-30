

CREATE Procedure jag_spI_Permit
-- Inserts a new record in [Permit] table
(
  @DatePermit [smalldatetime] = Null  -- for [Permit].[DatePermit] column
, @DateDebut [smalldatetime] = Null  -- for [Permit].[DateDebut] column
, @DateFin [smalldatetime] = Null  -- for [Permit].[DateFin] column
, @Annee [int] = Null  -- for [Permit].[Annee] column
, @Periode [int] = Null  -- for [Permit].[Periode] column
, @ContratID [varchar](10) = Null  -- for [Permit].[ContratID] column
, @EssenceID [varchar](6) = Null  -- for [Permit].[EssenceID] column
, @Code [char](4) = Null  -- for [Permit].[EssenceID] column
, @PermitSciage [bit] = Null  -- for [Permit].[PermitSciage] column
, @TransporteurID [varchar](15) = Null  -- for [Permit].[TransporteurID] column
, @VR [varchar](10) = Null  -- for [Permit].[VR] column
, @LotID [int] = Null  -- for [Permit].[Lot] column
, @ProducteurDroitCoupeID [varchar](15) = Null  -- for [Permit].[ProducteurDroitCoupeID] column
, @ProducteurEntentePaiementID [varchar](15) = Null  -- for [Permit].[ProducteurEntentePaiementID] column
, @PermitLivre [bit] = Null  -- for [Permit].[PermitLivre] column
, @PermitImprime [bit] = Null  -- for [Permit].[PermitImprime] column
, @PermitAnnule [bit] = Null  -- for [Permit].[PermitAnnule] column
, @EssenceSciage [varchar](25) = Null  -- for [Permit].[EssenceSciage] column
, @MunicipaliteID [varchar](6) = Null  -- for [Permit].[EssenceSciage] column
, @ZoneID [varchar](2) = Null  -- for [Permit].[EssenceSciage] column
, @ChargeurID [varchar](15) = Null  -- for [Permit].[EssenceSciage] column
, @Remarques [varchar](2000) = Null  -- for [Permit].[EssenceSciage] column
)

As

/*
	This T-SQL code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 3/8/2004 8:46:08 AM
			Generator name: <Developer Name Here>
			Template last update: 6/24/2002 1:53:57 AM
			Template revision: 15083637

			SQL Server version: 08.00.0194
			Server: ANDRE
			Database: [Gestion_Paie]

	WARNING: This source is provided "AS IS" without warranty of any kind.
	The author disclaims all warranties, either express or implied, including
	the warranties of merchantability and fitness for a particular purpose.
	In no event shall the author or its suppliers be liable for any damages
	whatsoever including direct, indirect, incidental, consequential, loss of
	business profits or special damages, even if the author or its suppliers
	have been advised of the possibility of such damages.
*/


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

declare @MaxIDPlus1 int -- for [Permit].[ID] column
set @MaxIDPlus1 = (select (max(ID)+1) from [dbo].[Permit])

if @MaxIDPlus1 is Null
Begin
	set @MaxIDPlus1 = 1
End

Insert Into [dbo].[Permit]
(
	  [ID]
	, [DatePermit]
	, [DateDebut]
	, [DateFin]
	, [Annee]
	, [Periode]
	, [ContratID]
	, [EssenceID]
	, [Code]
	, [PermitSciage]
	, [TransporteurID]
	, [VR]
	, [LotID]
	, [ProducteurDroitCoupeID]
	, [ProducteurEntentePaiementID]
	, [PermitLivre]
	, [PermitImprime]
	, [PermitAnnule]
	, [EssenceSciage]
	, [MunicipaliteID]
	, [ZoneID]
	, [ChargeurID]
	, [Remarques]
)

Values
(
	  @MaxIDPlus1
	, @DatePermit
	, @DateDebut
	, @DateFin
	, @Annee
	, @Periode
	, @ContratID
	, @EssenceID
	, @Code
	, @PermitSciage
	, @TransporteurID
	, @VR
	, @LotID
	, @ProducteurDroitCoupeID
	, @ProducteurEntentePaiementID
	, @PermitLivre
	, @PermitImprime
	, @PermitAnnule
	, @EssenceSciage
	, @MunicipaliteID
	, @ZoneID
	, @ChargeurID
	, @Remarques
)

Set NoCount Off

Return(0)

