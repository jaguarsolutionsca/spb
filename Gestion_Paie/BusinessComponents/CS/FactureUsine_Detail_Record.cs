using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [FactureUsine_Detail] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.FactureUsine_Detail_Collection"/> class to do so.
	/// </summary>
	public sealed class FactureUsine_Detail_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the FactureUsine_Detail_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.FactureUsine_Detail_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public FactureUsine_Detail_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public FactureUsine_Detail_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine_Detail'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureUsine_Detail", CurrentRevision, OriginalRevision));
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
		
		internal bool col_FactureUsineIDWasSet = false;
		private bool col_FactureUsineIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_FactureUsineID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_FactureUsineID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_FactureUsineID);
			}
			set {
			
				this.col_FactureUsineIDWasUpdated = true;
				this.col_FactureUsineIDWasSet = true;
				this.col_FactureUsineID_Record = null;
				this.col_FactureUsineID = value;
			}
		}

		
		private FactureUsine_Record col_FactureUsineID_Record = null;
		public FactureUsine_Record Col_FactureUsineID_FactureUsine_Record {
		
			get {

				if (this.col_FactureUsineID_Record == null) {
				
					this.col_FactureUsineID_Record = new FactureUsine_Record(this.connectionString, this.col_FactureUsineID);
				}
				
				return(this.col_FactureUsineID_Record);
			}
		}

		internal bool col_ContratIDWasSet = false;
		private bool col_ContratIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ContratID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ContratID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ContratID);
			}
			set {
			
				this.col_ContratIDWasUpdated = true;
				this.col_ContratIDWasSet = true;
				this.col_ContratID = value;
			}
		}

		internal bool col_ProducteurIDWasSet = false;
		private bool col_ProducteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProducteurID);
			}
			set {
			
				this.col_ProducteurIDWasUpdated = true;
				this.col_ProducteurIDWasSet = true;
				this.col_ProducteurID_Record = null;
				this.col_ProducteurID = value;
			}
		}

		
		private Fournisseur_Record col_ProducteurID_Record = null;
		public Fournisseur_Record Col_ProducteurID_Fournisseur_Record {
		
			get {

				if (this.col_ProducteurID_Record == null) {
				
					this.col_ProducteurID_Record = new Fournisseur_Record(this.connectionString, this.col_ProducteurID);
				}
				
				return(this.col_ProducteurID_Record);
			}
		}

		internal bool col_ProducteurEntentePaiementIDWasSet = false;
		private bool col_ProducteurEntentePaiementIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProducteurEntentePaiementID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurEntentePaiementID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProducteurEntentePaiementID);
			}
			set {
			
				this.col_ProducteurEntentePaiementIDWasUpdated = true;
				this.col_ProducteurEntentePaiementIDWasSet = true;
				this.col_ProducteurEntentePaiementID_Record = null;
				this.col_ProducteurEntentePaiementID = value;
			}
		}

		
		private Fournisseur_Record col_ProducteurEntentePaiementID_Record = null;
		public Fournisseur_Record Col_ProducteurEntentePaiementID_Fournisseur_Record {
		
			get {

				if (this.col_ProducteurEntentePaiementID_Record == null) {
				
					this.col_ProducteurEntentePaiementID_Record = new Fournisseur_Record(this.connectionString, this.col_ProducteurEntentePaiementID);
				}
				
				return(this.col_ProducteurEntentePaiementID_Record);
			}
		}

		internal bool col_ZoneIDWasSet = false;
		private bool col_ZoneIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ZoneID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ZoneID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ZoneID);
			}
			set {
			
				this.col_ZoneIDWasUpdated = true;
				this.col_ZoneIDWasSet = true;
				this.col_ZoneID_Record = null;
				this.col_ZoneID = value;
			}
		}

		
		private Municipalite_Zone_Record col_ZoneID_Record = null;
		public Municipalite_Zone_Record Col_ZoneID_Municipalite_Zone_Record {
		
			get {

				if (this.col_ZoneID_Record == null) {
				
					this.col_ZoneID_Record = new Municipalite_Zone_Record(this.connectionString, this.col_ZoneID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_ZoneID_Record);
			}
		}

		internal bool col_MunicipaliteIDWasSet = false;
		private bool col_MunicipaliteIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MunicipaliteID);
			}
			set {
			
				this.col_MunicipaliteIDWasUpdated = true;
				this.col_MunicipaliteIDWasSet = true;
				this.col_MunicipaliteID_Record = null;
				this.col_MunicipaliteID = value;
			}
		}

		
		private Municipalite_Zone_Record col_MunicipaliteID_Record = null;
		public Municipalite_Zone_Record Col_MunicipaliteID_Municipalite_Zone_Record {
		
			get {

				if (this.col_MunicipaliteID_Record == null) {
				
					this.col_MunicipaliteID_Record = new Municipalite_Zone_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, this.col_MunicipaliteID);
				}
				
				return(this.col_MunicipaliteID_Record);
			}
		}

		internal bool col_LotIDWasSet = false;
		private bool col_LotIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_LotID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LotID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_LotID);
			}
			set {
			
				this.col_LotIDWasUpdated = true;
				this.col_LotIDWasSet = true;
				this.col_LotID_Record = null;
				this.col_LotID = value;
			}
		}

		
		private Lot_Record col_LotID_Record = null;
		public Lot_Record Col_LotID_Lot_Record {
		
			get {

				if (this.col_LotID_Record == null) {
				
					this.col_LotID_Record = new Lot_Record(this.connectionString, this.col_LotID);
				}
				
				return(this.col_LotID_Record);
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

		internal bool col_LivraisonIDWasSet = false;
		private bool col_LivraisonIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_LivraisonID);
			}
			set {
			
				this.col_LivraisonIDWasUpdated = true;
				this.col_LivraisonIDWasSet = true;
				this.col_LivraisonID_Record = null;
				this.col_LivraisonID = value;
			}
		}

		
		private Livraison_Record col_LivraisonID_Record = null;
		public Livraison_Record Col_LivraisonID_Livraison_Record {
		
			get {

				if (this.col_LivraisonID_Record == null) {
				
					this.col_LivraisonID_Record = new Livraison_Record(this.connectionString, this.col_LivraisonID);
				}
				
				return(this.col_LivraisonID_Record);
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

		internal bool col_VolumeWasSet = false;
		private bool col_VolumeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Volume = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Volume {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume);
			}
			set {
			
				this.col_VolumeWasUpdated = true;
				this.col_VolumeWasSet = true;
				this.col_Volume = value;
			}
		}

		internal bool col_TauxWasSet = false;
		private bool col_TauxWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux);
			}
			set {
			
				this.col_TauxWasUpdated = true;
				this.col_TauxWasSet = true;
				this.col_Taux = value;
			}
		}

		internal bool col_MontantWasSet = false;
		private bool col_MontantWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant);
			}
			set {
			
				this.col_MontantWasUpdated = true;
				this.col_MontantWasSet = true;
				this.col_Montant = value;
			}
		}

		internal bool col_Taux_Usine_OverrideWasSet = false;
		private bool col_Taux_Usine_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Taux_Usine_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Taux_Usine_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Usine_Override);
			}
			set {
			
				this.col_Taux_Usine_OverrideWasUpdated = true;
				this.col_Taux_Usine_OverrideWasSet = true;
				this.col_Taux_Usine_Override = value;
			}
		}

		internal bool col_PermisIDWasSet = false;
		private bool col_PermisIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_PermisID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_PermisID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PermisID);
			}
			set {
			
				this.col_PermisIDWasUpdated = true;
				this.col_PermisIDWasSet = true;
				this.col_PermisID = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_FactureUsineIDWasUpdated = false;
			this.col_FactureUsineIDWasSet = false;
			this.col_FactureUsineID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_ProducteurIDWasUpdated = false;
			this.col_ProducteurIDWasSet = false;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_ProducteurEntentePaiementIDWasUpdated = false;
			this.col_ProducteurEntentePaiementIDWasSet = false;
			this.col_ProducteurEntentePaiementID = System.Data.SqlTypes.SqlString.Null;

			this.col_ZoneIDWasUpdated = false;
			this.col_ZoneIDWasSet = false;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;

			this.col_MunicipaliteIDWasUpdated = false;
			this.col_MunicipaliteIDWasSet = false;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;

			this.col_LotIDWasUpdated = false;
			this.col_LotIDWasSet = false;
			this.col_LotID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_UniteMesureIDWasUpdated = false;
			this.col_UniteMesureIDWasSet = false;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;

			this.col_LivraisonIDWasUpdated = false;
			this.col_LivraisonIDWasSet = false;
			this.col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_CodeWasUpdated = false;
			this.col_CodeWasSet = false;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;

			this.col_VolumeWasUpdated = false;
			this.col_VolumeWasSet = false;
			this.col_Volume = System.Data.SqlTypes.SqlDouble.Null;

			this.col_TauxWasUpdated = false;
			this.col_TauxWasSet = false;
			this.col_Taux = System.Data.SqlTypes.SqlDouble.Null;

			this.col_MontantWasUpdated = false;
			this.col_MontantWasSet = false;
			this.col_Montant = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_Usine_OverrideWasUpdated = false;
			this.col_Taux_Usine_OverrideWasSet = false;
			this.col_Taux_Usine_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_PermisIDWasUpdated = false;
			this.col_PermisIDWasSet = false;
			this.col_PermisID = System.Data.SqlTypes.SqlInt32.Null;

			Params.spS_FactureUsine_Detail Param = new Params.spS_FactureUsine_Detail(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureUsine_Detail Sp = new SPs.spS_FactureUsine_Detail();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_FactureUsineID.ColumnIndex)) {

						this.col_FactureUsineID = sqlDataReader.GetSqlInt32(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_FactureUsineID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = sqlDataReader.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ProducteurEntentePaiementID.ColumnIndex)) {

						this.col_ProducteurEntentePaiementID = sqlDataReader.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ProducteurEntentePaiementID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ZoneID.ColumnIndex)) {

						this.col_ZoneID = sqlDataReader.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_ZoneID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex)) {

						this.col_MunicipaliteID = sqlDataReader.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_LotID.ColumnIndex)) {

						this.col_LotID = sqlDataReader.GetSqlInt32(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_LotID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = sqlDataReader.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_LivraisonID.ColumnIndex)) {

						this.col_LivraisonID = sqlDataReader.GetSqlInt32(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_LivraisonID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = sqlDataReader.GetSqlString(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Code.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Volume.ColumnIndex)) {

						this.col_Volume = sqlDataReader.GetSqlDouble(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Volume.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Taux.ColumnIndex)) {

						this.col_Taux = sqlDataReader.GetSqlDouble(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Taux.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Montant.ColumnIndex)) {

						this.col_Montant = sqlDataReader.GetSqlDouble(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Montant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Taux_Usine_Override.ColumnIndex)) {

						this.col_Taux_Usine_Override = sqlDataReader.GetSqlBoolean(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_Taux_Usine_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_PermisID.ColumnIndex)) {

						this.col_PermisID = sqlDataReader.GetSqlInt32(SPs.spS_FactureUsine_Detail.Resultset1.Fields.Column_PermisID.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Detail_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FactureUsineIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurEntentePaiementIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ZoneIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MunicipaliteIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LotIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteMesureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LivraisonIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TauxWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MontantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_Usine_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PermisIDWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_FactureUsine_Detail Param = new Params.spU_FactureUsine_Detail(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_FactureUsineIDWasUpdated) {

				Param.Param_FactureUsineID = this.col_FactureUsineID;
				Param.Param_ConsiderNull_FactureUsineID = true;
			}

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_ProducteurIDWasUpdated) {

				Param.Param_ProducteurID = this.col_ProducteurID;
				Param.Param_ConsiderNull_ProducteurID = true;
			}

			if (this.col_ProducteurEntentePaiementIDWasUpdated) {

				Param.Param_ProducteurEntentePaiementID = this.col_ProducteurEntentePaiementID;
				Param.Param_ConsiderNull_ProducteurEntentePaiementID = true;
			}

			if (this.col_ZoneIDWasUpdated) {

				Param.Param_ZoneID = this.col_ZoneID;
				Param.Param_ConsiderNull_ZoneID = true;
			}

			if (this.col_MunicipaliteIDWasUpdated) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
				Param.Param_ConsiderNull_MunicipaliteID = true;
			}

			if (this.col_LotIDWasUpdated) {

				Param.Param_LotID = this.col_LotID;
				Param.Param_ConsiderNull_LotID = true;
			}

			if (this.col_UniteMesureIDWasUpdated) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
				Param.Param_ConsiderNull_UniteMesureID = true;
			}

			if (this.col_LivraisonIDWasUpdated) {

				Param.Param_LivraisonID = this.col_LivraisonID;
				Param.Param_ConsiderNull_LivraisonID = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_CodeWasUpdated) {

				Param.Param_Code = this.col_Code;
				Param.Param_ConsiderNull_Code = true;
			}

			if (this.col_VolumeWasUpdated) {

				Param.Param_Volume = this.col_Volume;
				Param.Param_ConsiderNull_Volume = true;
			}

			if (this.col_TauxWasUpdated) {

				Param.Param_Taux = this.col_Taux;
				Param.Param_ConsiderNull_Taux = true;
			}

			if (this.col_MontantWasUpdated) {

				Param.Param_Montant = this.col_Montant;
				Param.Param_ConsiderNull_Montant = true;
			}

			if (this.col_Taux_Usine_OverrideWasUpdated) {

				Param.Param_Taux_Usine_Override = this.col_Taux_Usine_Override;
				Param.Param_ConsiderNull_Taux_Usine_Override = true;
			}

			if (this.col_PermisIDWasUpdated) {

				Param.Param_PermisID = this.col_PermisID;
				Param.Param_ConsiderNull_PermisID = true;
			}

			SPs.spU_FactureUsine_Detail Sp = new SPs.spU_FactureUsine_Detail();
			if (Sp.Execute(ref Param)) {

				this.col_FactureUsineIDWasUpdated = false;
				this.col_ContratIDWasUpdated = false;
				this.col_ProducteurIDWasUpdated = false;
				this.col_ProducteurEntentePaiementIDWasUpdated = false;
				this.col_ZoneIDWasUpdated = false;
				this.col_MunicipaliteIDWasUpdated = false;
				this.col_LotIDWasUpdated = false;
				this.col_UniteMesureIDWasUpdated = false;
				this.col_LivraisonIDWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_CodeWasUpdated = false;
				this.col_VolumeWasUpdated = false;
				this.col_TauxWasUpdated = false;
				this.col_MontantWasUpdated = false;
				this.col_Taux_Usine_OverrideWasUpdated = false;
				this.col_PermisIDWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Detail_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_FactureUsine_Detail_Display Param = new Params.spS_FactureUsine_Detail_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_FactureUsine_Detail_Display Sp = new SPs.spS_FactureUsine_Detail_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Detail_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_FactureUsine_Detail_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Detail_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
