using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Contingentement] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Contingentement_Collection"/> class to do so.
	/// </summary>
	public sealed class Contingentement_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Contingentement_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Contingentement_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Contingentement_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Contingentement_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString != String.Empty) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ID {
		
			get {
			
				return(this.col_ID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ID = value;
				}
			}
		}
		
		internal bool col_ContingentUsineWasSet = false;
		private bool col_ContingentUsineWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_ContingentUsine = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_ContingentUsine {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ContingentUsine);
			}
			set {
			
				this.col_ContingentUsineWasUpdated = true;
				this.col_ContingentUsineWasSet = true;
				this.col_ContingentUsine = value;
			}
		}

		internal bool col_UsineIDWasSet = false;
		private bool col_UsineIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UsineID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UsineID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UsineID);
			}
			set {
			
				this.col_UsineIDWasUpdated = true;
				this.col_UsineIDWasSet = true;
				this.col_UsineID_Record = null;
				this.col_UsineID = value;
			}
		}

		
		private Usine_Record col_UsineID_Record = null;
		public Usine_Record Col_UsineID_Usine_Record {
		
			get {

				if (this.col_UsineID_Record == null) {
				
					this.col_UsineID_Record = new Usine_Record(this.connectionString, this.col_UsineID);
				}
				
				return(this.col_UsineID_Record);
			}
		}

		internal bool col_RegroupementIDWasSet = false;
		private bool col_RegroupementIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_RegroupementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_RegroupementID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_RegroupementID);
			}
			set {
			
				this.col_RegroupementIDWasUpdated = true;
				this.col_RegroupementIDWasSet = true;
				this.col_RegroupementID_Record = null;
				this.col_RegroupementID = value;
			}
		}

		
		private EssenceRegroupement_Record col_RegroupementID_Record = null;
		public EssenceRegroupement_Record Col_RegroupementID_EssenceRegroupement_Record {
		
			get {

				if (this.col_RegroupementID_Record == null) {
				
					this.col_RegroupementID_Record = new EssenceRegroupement_Record(this.connectionString, this.col_RegroupementID);
				}
				
				return(this.col_RegroupementID_Record);
			}
		}

		internal bool col_AnneeWasSet = false;
		private bool col_AnneeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Annee);
			}
			set {
			
				this.col_AnneeWasUpdated = true;
				this.col_AnneeWasSet = true;
				this.col_Annee = value;
			}
		}

		internal bool col_PeriodeContingentementWasSet = false;
		private bool col_PeriodeContingentementWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_PeriodeContingentement = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_PeriodeContingentement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PeriodeContingentement);
			}
			set {
			
				this.col_PeriodeContingentementWasUpdated = true;
				this.col_PeriodeContingentementWasSet = true;
				this.col_PeriodeContingentement = value;
			}
		}

		internal bool col_PeriodeDebutWasSet = false;
		private bool col_PeriodeDebutWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_PeriodeDebut = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_PeriodeDebut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PeriodeDebut);
			}
			set {
			
				this.col_PeriodeDebutWasUpdated = true;
				this.col_PeriodeDebutWasSet = true;
				this.col_PeriodeDebut = value;
			}
		}

		internal bool col_PeriodeFinWasSet = false;
		private bool col_PeriodeFinWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_PeriodeFin = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_PeriodeFin {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PeriodeFin);
			}
			set {
			
				this.col_PeriodeFinWasUpdated = true;
				this.col_PeriodeFinWasSet = true;
				this.col_PeriodeFin = value;
			}
		}

		internal bool col_EssenceIDWasSet = false;
		private bool col_EssenceIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_EssenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_EssenceID);
			}
			set {
			
				this.col_EssenceIDWasUpdated = true;
				this.col_EssenceIDWasSet = true;
				this.col_EssenceID_Record = null;
				this.col_EssenceID = value;
			}
		}

		
		private Essence_Record col_EssenceID_Record = null;
		public Essence_Record Col_EssenceID_Essence_Record {
		
			get {

				if (this.col_EssenceID_Record == null) {
				
					this.col_EssenceID_Record = new Essence_Record(this.connectionString, this.col_EssenceID);
				}
				
				return(this.col_EssenceID_Record);
			}
		}

		internal bool col_UniteMesureIDWasSet = false;
		private bool col_UniteMesureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UniteMesureID);
			}
			set {
			
				this.col_UniteMesureIDWasUpdated = true;
				this.col_UniteMesureIDWasSet = true;
				this.col_UniteMesureID_Record = null;
				this.col_UniteMesureID = value;
			}
		}

		
		private UniteMesure_Record col_UniteMesureID_Record = null;
		public UniteMesure_Record Col_UniteMesureID_UniteMesure_Record {
		
			get {

				if (this.col_UniteMesureID_Record == null) {
				
					this.col_UniteMesureID_Record = new UniteMesure_Record(this.connectionString, this.col_UniteMesureID);
				}
				
				return(this.col_UniteMesureID_Record);
			}
		}

		internal bool col_Volume_UsineWasSet = false;
		private bool col_Volume_UsineWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Usine = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Usine {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Usine);
			}
			set {
			
				this.col_Volume_UsineWasUpdated = true;
				this.col_Volume_UsineWasSet = true;
				this.col_Volume_Usine = value;
			}
		}

		internal bool col_FacteurWasSet = false;
		private bool col_FacteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Facteur = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Facteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Facteur);
			}
			set {
			
				this.col_FacteurWasUpdated = true;
				this.col_FacteurWasSet = true;
				this.col_Facteur = value;
			}
		}

		internal bool col_Volume_FixeWasSet = false;
		private bool col_Volume_FixeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Fixe {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Fixe);
			}
			set {
			
				this.col_Volume_FixeWasUpdated = true;
				this.col_Volume_FixeWasSet = true;
				this.col_Volume_Fixe = value;
			}
		}

		internal bool col_Date_CalculWasSet = false;
		private bool col_Date_CalculWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Date_Calcul = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Date_Calcul {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Date_Calcul);
			}
			set {
			
				this.col_Date_CalculWasUpdated = true;
				this.col_Date_CalculWasSet = true;
				this.col_Date_Calcul = value;
			}
		}

		internal bool col_CalculAccepteWasSet = false;
		private bool col_CalculAccepteWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_CalculAccepte = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_CalculAccepte {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_CalculAccepte);
			}
			set {
			
				this.col_CalculAccepteWasUpdated = true;
				this.col_CalculAccepteWasSet = true;
				this.col_CalculAccepte = value;
			}
		}

		internal bool col_CodeWasSet = false;
		private bool col_CodeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Code = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Code {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Code);
			}
			set {
			
				this.col_CodeWasUpdated = true;
				this.col_CodeWasSet = true;
				this.col_Code = value;
			}
		}

		internal bool col_Volume_RegroupementWasSet = false;
		private bool col_Volume_RegroupementWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Regroupement = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Regroupement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Regroupement);
			}
			set {
			
				this.col_Volume_RegroupementWasUpdated = true;
				this.col_Volume_RegroupementWasSet = true;
				this.col_Volume_Regroupement = value;
			}
		}

		internal bool col_Volume_RegroupementPourcentageWasSet = false;
		private bool col_Volume_RegroupementPourcentageWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_RegroupementPourcentage = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_RegroupementPourcentage {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_RegroupementPourcentage);
			}
			set {
			
				this.col_Volume_RegroupementPourcentageWasUpdated = true;
				this.col_Volume_RegroupementPourcentageWasSet = true;
				this.col_Volume_RegroupementPourcentage = value;
			}
		}

		internal bool col_MaxVolumeFixe_PourcentageWasSet = false;
		private bool col_MaxVolumeFixe_PourcentageWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_MaxVolumeFixe_Pourcentage = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_MaxVolumeFixe_Pourcentage {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MaxVolumeFixe_Pourcentage);
			}
			set {
			
				this.col_MaxVolumeFixe_PourcentageWasUpdated = true;
				this.col_MaxVolumeFixe_PourcentageWasSet = true;
				this.col_MaxVolumeFixe_Pourcentage = value;
			}
		}

		internal bool col_MaxVolumeFixe_ContingentementIDWasSet = false;
		private bool col_MaxVolumeFixe_ContingentementIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_MaxVolumeFixe_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_MaxVolumeFixe_ContingentementID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MaxVolumeFixe_ContingentementID);
			}
			set {
			
				this.col_MaxVolumeFixe_ContingentementIDWasUpdated = true;
				this.col_MaxVolumeFixe_ContingentementIDWasSet = true;
				this.col_MaxVolumeFixe_ContingentementID = value;
			}
		}

		internal bool col_UseVolumeFixeUniqueWasSet = false;
		private bool col_UseVolumeFixeUniqueWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_UseVolumeFixeUnique = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_UseVolumeFixeUnique {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UseVolumeFixeUnique);
			}
			set {
			
				this.col_UseVolumeFixeUniqueWasUpdated = true;
				this.col_UseVolumeFixeUniqueWasSet = true;
				this.col_UseVolumeFixeUnique = value;
			}
		}

		internal bool col_MasseContingentVoyageDefautWasSet = false;
		private bool col_MasseContingentVoyageDefautWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_MasseContingentVoyageDefaut = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_MasseContingentVoyageDefaut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MasseContingentVoyageDefaut);
			}
			set {
			
				this.col_MasseContingentVoyageDefautWasUpdated = true;
				this.col_MasseContingentVoyageDefautWasSet = true;
				this.col_MasseContingentVoyageDefaut = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_ContingentUsineWasUpdated = false;
			this.col_ContingentUsineWasSet = false;
			this.col_ContingentUsine = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_UsineIDWasUpdated = false;
			this.col_UsineIDWasSet = false;
			this.col_UsineID = System.Data.SqlTypes.SqlString.Null;

			this.col_RegroupementIDWasUpdated = false;
			this.col_RegroupementIDWasSet = false;
			this.col_RegroupementID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_AnneeWasUpdated = false;
			this.col_AnneeWasSet = false;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;

			this.col_PeriodeContingentementWasUpdated = false;
			this.col_PeriodeContingentementWasSet = false;
			this.col_PeriodeContingentement = System.Data.SqlTypes.SqlInt32.Null;

			this.col_PeriodeDebutWasUpdated = false;
			this.col_PeriodeDebutWasSet = false;
			this.col_PeriodeDebut = System.Data.SqlTypes.SqlInt32.Null;

			this.col_PeriodeFinWasUpdated = false;
			this.col_PeriodeFinWasSet = false;
			this.col_PeriodeFin = System.Data.SqlTypes.SqlInt32.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_UniteMesureIDWasUpdated = false;
			this.col_UniteMesureIDWasSet = false;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;

			this.col_Volume_UsineWasUpdated = false;
			this.col_Volume_UsineWasSet = false;
			this.col_Volume_Usine = System.Data.SqlTypes.SqlSingle.Null;

			this.col_FacteurWasUpdated = false;
			this.col_FacteurWasSet = false;
			this.col_Facteur = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Volume_FixeWasUpdated = false;
			this.col_Volume_FixeWasSet = false;
			this.col_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Date_CalculWasUpdated = false;
			this.col_Date_CalculWasSet = false;
			this.col_Date_Calcul = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_CalculAccepteWasUpdated = false;
			this.col_CalculAccepteWasSet = false;
			this.col_CalculAccepte = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_CodeWasUpdated = false;
			this.col_CodeWasSet = false;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;

			this.col_Volume_RegroupementWasUpdated = false;
			this.col_Volume_RegroupementWasSet = false;
			this.col_Volume_Regroupement = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Volume_RegroupementPourcentageWasUpdated = false;
			this.col_Volume_RegroupementPourcentageWasSet = false;
			this.col_Volume_RegroupementPourcentage = System.Data.SqlTypes.SqlSingle.Null;

			this.col_MaxVolumeFixe_PourcentageWasUpdated = false;
			this.col_MaxVolumeFixe_PourcentageWasSet = false;
			this.col_MaxVolumeFixe_Pourcentage = System.Data.SqlTypes.SqlSingle.Null;

			this.col_MaxVolumeFixe_ContingentementIDWasUpdated = false;
			this.col_MaxVolumeFixe_ContingentementIDWasSet = false;
			this.col_MaxVolumeFixe_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_UseVolumeFixeUniqueWasUpdated = false;
			this.col_UseVolumeFixeUniqueWasSet = false;
			this.col_UseVolumeFixeUnique = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_MasseContingentVoyageDefautWasUpdated = false;
			this.col_MasseContingentVoyageDefautWasSet = false;
			this.col_MasseContingentVoyageDefaut = System.Data.SqlTypes.SqlSingle.Null;

			Params.spS_Contingentement Param = new Params.spS_Contingentement(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contingentement Sp = new SPs.spS_Contingentement();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_ContingentUsine.ColumnIndex)) {

						this.col_ContingentUsine = sqlDataReader.GetSqlBoolean(SPs.spS_Contingentement.Resultset1.Fields.Column_ContingentUsine.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_UsineID.ColumnIndex)) {

						this.col_UsineID = sqlDataReader.GetSqlString(SPs.spS_Contingentement.Resultset1.Fields.Column_UsineID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_RegroupementID.ColumnIndex)) {

						this.col_RegroupementID = sqlDataReader.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_RegroupementID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = sqlDataReader.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_Annee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeContingentement.ColumnIndex)) {

						this.col_PeriodeContingentement = sqlDataReader.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeContingentement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeDebut.ColumnIndex)) {

						this.col_PeriodeDebut = sqlDataReader.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeDebut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeFin.ColumnIndex)) {

						this.col_PeriodeFin = sqlDataReader.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_PeriodeFin.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_Contingentement.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = sqlDataReader.GetSqlString(SPs.spS_Contingentement.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Usine.ColumnIndex)) {

						this.col_Volume_Usine = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Usine.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Facteur.ColumnIndex)) {

						this.col_Facteur = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Facteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex)) {

						this.col_Volume_Fixe = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Date_Calcul.ColumnIndex)) {

						this.col_Date_Calcul = sqlDataReader.GetSqlDateTime(SPs.spS_Contingentement.Resultset1.Fields.Column_Date_Calcul.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_CalculAccepte.ColumnIndex)) {

						this.col_CalculAccepte = sqlDataReader.GetSqlBoolean(SPs.spS_Contingentement.Resultset1.Fields.Column_CalculAccepte.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = sqlDataReader.GetSqlString(SPs.spS_Contingentement.Resultset1.Fields.Column_Code.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Regroupement.ColumnIndex)) {

						this.col_Volume_Regroupement = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_Regroupement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_RegroupementPourcentage.ColumnIndex)) {

						this.col_Volume_RegroupementPourcentage = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_Volume_RegroupementPourcentage.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_MaxVolumeFixe_Pourcentage.ColumnIndex)) {

						this.col_MaxVolumeFixe_Pourcentage = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_MaxVolumeFixe_Pourcentage.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_MaxVolumeFixe_ContingentementID.ColumnIndex)) {

						this.col_MaxVolumeFixe_ContingentementID = sqlDataReader.GetSqlInt32(SPs.spS_Contingentement.Resultset1.Fields.Column_MaxVolumeFixe_ContingentementID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_UseVolumeFixeUnique.ColumnIndex)) {

						this.col_UseVolumeFixeUnique = sqlDataReader.GetSqlBoolean(SPs.spS_Contingentement.Resultset1.Fields.Column_UseVolumeFixeUnique.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement.Resultset1.Fields.Column_MasseContingentVoyageDefaut.ColumnIndex)) {

						this.col_MasseContingentVoyageDefaut = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement.Resultset1.Fields.Column_MasseContingentVoyageDefaut.ColumnIndex);
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = true;

					return(true);
				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = false;

					return(false);
				}
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContingentUsineWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UsineIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RegroupementIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AnneeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PeriodeContingentementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PeriodeDebutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PeriodeFinWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteMesureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_UsineWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FacteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_FixeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Date_CalculWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CalculAccepteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_RegroupementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_RegroupementPourcentageWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MaxVolumeFixe_PourcentageWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MaxVolumeFixe_ContingentementIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UseVolumeFixeUniqueWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MasseContingentVoyageDefautWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Contingentement Param = new Params.spU_Contingentement(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_ContingentUsineWasUpdated) {

				Param.Param_ContingentUsine = this.col_ContingentUsine;
				Param.Param_ConsiderNull_ContingentUsine = true;
			}

			if (this.col_UsineIDWasUpdated) {

				Param.Param_UsineID = this.col_UsineID;
				Param.Param_ConsiderNull_UsineID = true;
			}

			if (this.col_RegroupementIDWasUpdated) {

				Param.Param_RegroupementID = this.col_RegroupementID;
				Param.Param_ConsiderNull_RegroupementID = true;
			}

			if (this.col_AnneeWasUpdated) {

				Param.Param_Annee = this.col_Annee;
				Param.Param_ConsiderNull_Annee = true;
			}

			if (this.col_PeriodeContingentementWasUpdated) {

				Param.Param_PeriodeContingentement = this.col_PeriodeContingentement;
				Param.Param_ConsiderNull_PeriodeContingentement = true;
			}

			if (this.col_PeriodeDebutWasUpdated) {

				Param.Param_PeriodeDebut = this.col_PeriodeDebut;
				Param.Param_ConsiderNull_PeriodeDebut = true;
			}

			if (this.col_PeriodeFinWasUpdated) {

				Param.Param_PeriodeFin = this.col_PeriodeFin;
				Param.Param_ConsiderNull_PeriodeFin = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_UniteMesureIDWasUpdated) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
				Param.Param_ConsiderNull_UniteMesureID = true;
			}

			if (this.col_Volume_UsineWasUpdated) {

				Param.Param_Volume_Usine = this.col_Volume_Usine;
				Param.Param_ConsiderNull_Volume_Usine = true;
			}

			if (this.col_FacteurWasUpdated) {

				Param.Param_Facteur = this.col_Facteur;
				Param.Param_ConsiderNull_Facteur = true;
			}

			if (this.col_Volume_FixeWasUpdated) {

				Param.Param_Volume_Fixe = this.col_Volume_Fixe;
				Param.Param_ConsiderNull_Volume_Fixe = true;
			}

			if (this.col_Date_CalculWasUpdated) {

				Param.Param_Date_Calcul = this.col_Date_Calcul;
				Param.Param_ConsiderNull_Date_Calcul = true;
			}

			if (this.col_CalculAccepteWasUpdated) {

				Param.Param_CalculAccepte = this.col_CalculAccepte;
				Param.Param_ConsiderNull_CalculAccepte = true;
			}

			if (this.col_CodeWasUpdated) {

				Param.Param_Code = this.col_Code;
				Param.Param_ConsiderNull_Code = true;
			}

			if (this.col_Volume_RegroupementWasUpdated) {

				Param.Param_Volume_Regroupement = this.col_Volume_Regroupement;
				Param.Param_ConsiderNull_Volume_Regroupement = true;
			}

			if (this.col_Volume_RegroupementPourcentageWasUpdated) {

				Param.Param_Volume_RegroupementPourcentage = this.col_Volume_RegroupementPourcentage;
				Param.Param_ConsiderNull_Volume_RegroupementPourcentage = true;
			}

			if (this.col_MaxVolumeFixe_PourcentageWasUpdated) {

				Param.Param_MaxVolumeFixe_Pourcentage = this.col_MaxVolumeFixe_Pourcentage;
				Param.Param_ConsiderNull_MaxVolumeFixe_Pourcentage = true;
			}

			if (this.col_MaxVolumeFixe_ContingentementIDWasUpdated) {

				Param.Param_MaxVolumeFixe_ContingentementID = this.col_MaxVolumeFixe_ContingentementID;
				Param.Param_ConsiderNull_MaxVolumeFixe_ContingentementID = true;
			}

			if (this.col_UseVolumeFixeUniqueWasUpdated) {

				Param.Param_UseVolumeFixeUnique = this.col_UseVolumeFixeUnique;
				Param.Param_ConsiderNull_UseVolumeFixeUnique = true;
			}

			if (this.col_MasseContingentVoyageDefautWasUpdated) {

				Param.Param_MasseContingentVoyageDefaut = this.col_MasseContingentVoyageDefaut;
				Param.Param_ConsiderNull_MasseContingentVoyageDefaut = true;
			}

			SPs.spU_Contingentement Sp = new SPs.spU_Contingentement();
			if (Sp.Execute(ref Param)) {

				this.col_ContingentUsineWasUpdated = false;
				this.col_UsineIDWasUpdated = false;
				this.col_RegroupementIDWasUpdated = false;
				this.col_AnneeWasUpdated = false;
				this.col_PeriodeContingentementWasUpdated = false;
				this.col_PeriodeDebutWasUpdated = false;
				this.col_PeriodeFinWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_UniteMesureIDWasUpdated = false;
				this.col_Volume_UsineWasUpdated = false;
				this.col_FacteurWasUpdated = false;
				this.col_Volume_FixeWasUpdated = false;
				this.col_Date_CalculWasUpdated = false;
				this.col_CalculAccepteWasUpdated = false;
				this.col_CodeWasUpdated = false;
				this.col_Volume_RegroupementWasUpdated = false;
				this.col_Volume_RegroupementPourcentageWasUpdated = false;
				this.col_MaxVolumeFixe_PourcentageWasUpdated = false;
				this.col_MaxVolumeFixe_ContingentementIDWasUpdated = false;
				this.col_UseVolumeFixeUniqueWasUpdated = false;
				this.col_MasseContingentVoyageDefautWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Record", "Update");
			}		
		}

		private Contingentement_Producteur_Collection internal_Contingentement_Producteur_Col_ContingentementID_Collection = null;
		public Contingentement_Producteur_Collection Contingentement_Producteur_Col_ContingentementID_Collection {

			get {

				if (this.internal_Contingentement_Producteur_Col_ContingentementID_Collection == null) {

					this.internal_Contingentement_Producteur_Col_ContingentementID_Collection = new Contingentement_Producteur_Collection(this.connectionString);
					this.internal_Contingentement_Producteur_Col_ContingentementID_Collection.LoadFrom_ContingentementID(this.col_ID, this);
				}

				return(this.internal_Contingentement_Producteur_Col_ContingentementID_Collection);
			}
		}

		private Contingentement_Unite_Collection internal_Contingentement_Unite_Col_ContingentementID_Collection = null;
		public Contingentement_Unite_Collection Contingentement_Unite_Col_ContingentementID_Collection {

			get {

				if (this.internal_Contingentement_Unite_Col_ContingentementID_Collection == null) {

					this.internal_Contingentement_Unite_Col_ContingentementID_Collection = new Contingentement_Unite_Collection(this.connectionString);
					this.internal_Contingentement_Unite_Col_ContingentementID_Collection.LoadFrom_ContingentementID(this.col_ID, this);
				}

				return(this.internal_Contingentement_Unite_Col_ContingentementID_Collection);
			}
		}

		private Contingentement_VolumeFixe_Collection internal_Contingentement_VolumeFixe_Col_ContingentementID_Collection = null;
		public Contingentement_VolumeFixe_Collection Contingentement_VolumeFixe_Col_ContingentementID_Collection {

			get {

				if (this.internal_Contingentement_VolumeFixe_Col_ContingentementID_Collection == null) {

					this.internal_Contingentement_VolumeFixe_Col_ContingentementID_Collection = new Contingentement_VolumeFixe_Collection(this.connectionString);
					this.internal_Contingentement_VolumeFixe_Col_ContingentementID_Collection.LoadFrom_ContingentementID(this.col_ID, this);
				}

				return(this.internal_Contingentement_VolumeFixe_Col_ContingentementID_Collection);
			}
		}

		private Livraison_Detail_Collection internal_Livraison_Detail_Col_ContingentementID_Collection = null;
		public Livraison_Detail_Collection Livraison_Detail_Col_ContingentementID_Collection {

			get {

				if (this.internal_Livraison_Detail_Col_ContingentementID_Collection == null) {

					this.internal_Livraison_Detail_Col_ContingentementID_Collection = new Livraison_Detail_Collection(this.connectionString);
					this.internal_Livraison_Detail_Col_ContingentementID_Collection.LoadFrom_ContingentementID(this.col_ID, this);
				}

				return(this.internal_Livraison_Detail_Col_ContingentementID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Contingentement_Display Param = new Params.spS_Contingentement_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Contingentement_Display Sp = new SPs.spS_Contingentement_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Contingentement_Display";
						}
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
