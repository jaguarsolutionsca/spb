
CREATE Procedure [spI_Ajustement]

-- Inserts a new record in [Ajustement] table
(
  @ID [int] = Null Output -- for [Ajustement].[ID] column
, @ContratID [varchar](10) = Null  -- for [Ajustement].[ContratID] column
, @DateAjustement [datetime] = Null  -- for [Ajustement].[DateAjustement] column
, @Periode_Debut [int] = Null  -- for [Ajustement].[Periode_Debut] column
, @Periode_Fin [int] = Null  -- for [Ajustement].[Periode_Fin] column
, @Facture [bit] = Null  -- for [Ajustement].[Facture] column
, @UsePeriodes [bit] = Null  -- for [Ajustement].[UsePeriodes] column
, @Date_Debut [smalldatetime] = Null  -- for [Ajustement].[Date_Debut] column
, @Date_Fin [smalldatetime] = Null  -- for [Ajustement].[Date_Fin] column
, @ProducteurID [varchar](15) = Null  -- for [Ajustement].[ProducteurID] column
, @TransporteurID [varchar](15) = Null  -- for [Ajustement].[TransporteurID] column
, @IsRistourne [bit] = Null  -- for [Ajustement].[IsRistourne] column
)

As


--	IMPORTANT:
--	Changes to this SQL code may cause incorrect behavior
--	and will be lost if the code is regenerated. 


Set NoCount On

If @IsRistourne Is Null
	Set @IsRistourne = (0)

If @ID Is Null
	Begin

		Insert Into [dbo].[Ajustement]
		(
			  [ContratID]
			, [DateAjustement]
			, [Periode_Debut]
			, [Periode_Fin]
			, [Facture]
			, [UsePeriodes]
			, [Date_Debut]
			, [Date_Fin]
			, [ProducteurID]
			, [TransporteurID]
			, [IsRistourne]
		)

		Values
		(
			  @ContratID
			, @DateAjustement
			, @Periode_Debut
			, @Periode_Fin
			, @Facture
			, @UsePeriodes
			, @Date_Debut
			, @Date_Fin
			, @ProducteurID
			, @TransporteurID
			, @IsRistourne
		)

		Set @ID = Cast(SCOPE_IDENTITY() As [int])

	End

Else
	Begin
		Set Identity_Insert [dbo].[Ajustement] On

		Insert Into [dbo].[Ajustement]
		(
			  [ID]
			, [ContratID]
			, [DateAjustement]
			, [Periode_Debut]
			, [Periode_Fin]
			, [Facture]
			, [UsePeriodes]
			, [Date_Debut]
			, [Date_Fin]
			, [ProducteurID]
			, [TransporteurID]
			, [IsRistourne]
		)

		Values
		(
			  @ID
			, @ContratID
			, @DateAjustement
			, @Periode_Debut
			, @Periode_Fin
			, @Facture
			, @UsePeriodes
			, @Date_Debut
			, @Date_Fin
			, @ProducteurID
			, @TransporteurID
			, @IsRistourne
		)

		Set Identity_Insert [dbo].[Ajustement] Off

	End

Set NoCount Off

Return(0)

