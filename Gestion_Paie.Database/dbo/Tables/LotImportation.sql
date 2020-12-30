CREATE TABLE [dbo].[LotImportation] (
    [lo_code_canton]      VARCHAR (6)    NULL,
    [lo_rang]             VARCHAR (25)   NULL,
    [lo_code]             VARCHAR (6)    NULL,
    [lo_super_tot]        VARCHAR (50)   NULL,
    [lo_super_boisee]     VARCHAR (50)   NULL,
    [lo_super_contin]     VARCHAR (50)   NULL,
    [lo_code_fournisseur] VARCHAR (6)    NULL,
    [lo_code_muni]        VARCHAR (6)    NULL,
    [lo_code_prop]        VARCHAR (6)    NULL,
    [lo_code_cont]        VARCHAR (6)    NULL,
    [lo_date]             VARCHAR (50)   NULL,
    [lo_code_deux]        VARCHAR (6)    NULL,
    [Traite]              BIT            NULL,
    [Valide]              BIT            NULL,
    [Raison]              VARCHAR (2000) NULL
);

