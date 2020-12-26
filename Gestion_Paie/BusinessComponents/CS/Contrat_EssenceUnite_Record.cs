using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Contrat_EssenceUnite] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Contrat_EssenceUnite_Collection"/> class to do so.
	/// </summary>
	public sealed class Contrat_EssenceUnite_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Contrat_EssenceUnite_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Contrat_EssenceUnite_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Contrat_EssenceUnite_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ContratID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_UniteID">[To be supplied.]</param>
		/// <param name="col_Code">[To be supplied.]</param>
		public Contrat_EssenceUnite_Record(string connectionString, System.Data.SqlTypes.SqlString col_ContratID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteID, System.Data.SqlTypes.SqlString col_Code) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat_EssenceUnite'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contrat_EssenceUnite", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ContratID = col_ContratID;
			this.col_EssenceID = col_EssenceID;
			this.col_UniteID = col_UniteID;
			this.col_Code = col_Code;
		}
		
		internal System.Data.SqlTypes.SqlString col_ContratID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ContratID {
		
			get {
			
				return(this.col_ContratID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ContratID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_EssenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceID {
		
			get {
			
				return(this.col_EssenceID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_EssenceID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_UniteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteID {
		
			get {
			
				return(this.col_UniteID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_UniteID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_Code = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Code {
		
			get {
			
				return(this.col_Code);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Code = value;
				}
			}
		}
		
		
		private Contrat_Record col_ContratID_Record = null;
		public Contrat_Record Col_ContratID_Contrat_Record {
		
			get {

				if (this.col_ContratID_Record == null) {
				
					this.col_ContratID_Record = new Contrat_Record(this.connectionString, this.col_ContratID);
				}
				
				return(this.col_ContratID_Record);
			}
		}

		
		private Essence_Unite_Record col_EssenceID_Record = null;
		public Essence_Unite_Record Col_EssenceID_Essence_Unite_Record {
		
			get {

				if (this.col_EssenceID_Record == null) {
				
					this.col_EssenceID_Record = new Essence_Unite_Record(this.connectionString, this.col_EssenceID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_EssenceID_Record);
			}
		}

		
		private Essence_Unite_Record col_UniteID_Record = null;
		public Essence_Unite_Record Col_UniteID_Essence_Unite_Record {
		
			get {

				if (this.col_UniteID_Record == null) {
				
					this.col_UniteID_Record = new Essence_Unite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, this.col_UniteID);
				}
				
				return(this.col_UniteID_Record);
			}
		}

		internal bool col_Quantite_prevueWasSet = false;
		private bool col_Quantite_prevueWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Quantite_prevue = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Quantite_prevue {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Quantite_prevue);
			}
			set {
			
				this.col_Quantite_prevueWasUpdated = true;
				this.col_Quantite_prevueWasSet = true;
				this.col_Quantite_prevue = value;
			}
		}

		internal bool col_Taux_usineWasSet = false;
		private bool col_Taux_usineWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_usine = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_usine {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_usine);
			}
			set {
			
				this.col_Taux_usineWasUpdated = true;
				this.col_Taux_usineWasSet = true;
				this.col_Taux_usine = value;
			}
		}

		internal bool col_Taux_producteurWasSet = false;
		private bool col_Taux_producteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Taux_producteur = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Taux_producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_producteur);
			}
			set {
			
				this.col_Taux_producteurWasUpdated = true;
				this.col_Taux_producteurWasSet = true;
				this.col_Taux_producteur = value;
			}
		}

		internal bool col_ActifWasSet = false;
		private bool col_ActifWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Actif {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Actif);
			}
			set {
			
				this.col_ActifWasUpdated = true;
				this.col_ActifWasSet = true;
				this.col_Actif = value;
			}
		}

		internal bool col_DescriptionWasSet = false;
		private bool col_DescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Description = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Description {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Description);
			}
			set {
			
				this.col_DescriptionWasUpdated = true;
				this.col_DescriptionWasSet = true;
				this.col_Description = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;




			this.col_Quantite_prevueWasUpdated = false;
			this.col_Quantite_prevueWasSet = false;
			this.col_Quantite_prevue = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_usineWasUpdated = false;
			this.col_Taux_usineWasSet = false;
			this.col_Taux_usine = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_producteurWasUpdated = false;
			this.col_Taux_producteurWasSet = false;
			this.col_Taux_producteur = System.Data.SqlTypes.SqlSingle.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_DescriptionWasUpdated = false;
			this.col_DescriptionWasSet = false;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;

			Params.spS_Contrat_EssenceUnite Param = new Params.spS_Contrat_EssenceUnite(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ContratID.IsNull) {

				Param.Param_ContratID = this.col_ContratID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_UniteID.IsNull) {

				Param.Param_UniteID = this.col_UniteID;
			}

			if (!this.col_Code.IsNull) {

				Param.Param_Code = this.col_Code;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contrat_EssenceUnite Sp = new SPs.spS_Contrat_EssenceUnite();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Quantite_prevue.ColumnIndex)) {

						this.col_Quantite_prevue = sqlDataReader.GetSqlDouble(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Quantite_prevue.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Taux_usine.ColumnIndex)) {

						this.col_Taux_usine = sqlDataReader.GetSqlDouble(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Taux_usine.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Taux_producteur.ColumnIndex)) {

						this.col_Taux_producteur = sqlDataReader.GetSqlSingle(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Taux_producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Actif.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_Contrat_EssenceUnite.Resultset1.Fields.Column_Description.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_EssenceUnite_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Quantite_prevueWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_usineWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_producteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Contrat_EssenceUnite Param = new Params.spU_Contrat_EssenceUnite(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ContratID = this.col_ContratID;
			Param.Param_EssenceID = this.col_EssenceID;
			Param.Param_UniteID = this.col_UniteID;
			Param.Param_Code = this.col_Code;

			if (this.col_Quantite_prevueWasUpdated) {

				Param.Param_Quantite_prevue = this.col_Quantite_prevue;
				Param.Param_ConsiderNull_Quantite_prevue = true;
			}

			if (this.col_Taux_usineWasUpdated) {

				Param.Param_Taux_usine = this.col_Taux_usine;
				Param.Param_ConsiderNull_Taux_usine = true;
			}

			if (this.col_Taux_producteurWasUpdated) {

				Param.Param_Taux_producteur = this.col_Taux_producteur;
				Param.Param_ConsiderNull_Taux_producteur = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			SPs.spU_Contrat_EssenceUnite Sp = new SPs.spU_Contrat_EssenceUnite();
			if (Sp.Execute(ref Param)) {

				this.col_Quantite_prevueWasUpdated = false;
				this.col_Taux_usineWasUpdated = false;
				this.col_Taux_producteurWasUpdated = false;
				this.col_ActifWasUpdated = false;
				this.col_DescriptionWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_EssenceUnite_Record", "Update");
			}		
		}

		private Ajustement_EssenceUnite_Collection internal_Ajustement_EssenceUnite_Col_EssenceID_Collection = null;
		public Ajustement_EssenceUnite_Collection Ajustement_EssenceUnite_Col_EssenceID_Collection {

			get {

				if (this.internal_Ajustement_EssenceUnite_Col_EssenceID_Collection == null) {

					this.internal_Ajustement_EssenceUnite_Col_EssenceID_Collection = new Ajustement_EssenceUnite_Collection(this.connectionString);
					this.internal_Ajustement_EssenceUnite_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_EssenceID, this);
				}

				return(this.internal_Ajustement_EssenceUnite_Col_EssenceID_Collection);
			}
		}

		private Ajustement_EssenceUnite_Collection internal_Ajustement_EssenceUnite_Col_UniteID_Collection = null;
		public Ajustement_EssenceUnite_Collection Ajustement_EssenceUnite_Col_UniteID_Collection {

			get {

				if (this.internal_Ajustement_EssenceUnite_Col_UniteID_Collection == null) {

					this.internal_Ajustement_EssenceUnite_Col_UniteID_Collection = new Ajustement_EssenceUnite_Collection(this.connectionString);
					this.internal_Ajustement_EssenceUnite_Col_UniteID_Collection.LoadFrom_UniteID(this.col_UniteID, this);
				}

				return(this.internal_Ajustement_EssenceUnite_Col_UniteID_Collection);
			}
		}

		private Ajustement_EssenceUnite_Collection internal_Ajustement_EssenceUnite_Col_ContratID_Collection = null;
		public Ajustement_EssenceUnite_Collection Ajustement_EssenceUnite_Col_ContratID_Collection {

			get {

				if (this.internal_Ajustement_EssenceUnite_Col_ContratID_Collection == null) {

					this.internal_Ajustement_EssenceUnite_Col_ContratID_Collection = new Ajustement_EssenceUnite_Collection(this.connectionString);
					this.internal_Ajustement_EssenceUnite_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ContratID, this);
				}

				return(this.internal_Ajustement_EssenceUnite_Col_ContratID_Collection);
			}
		}

		private Ajustement_EssenceUnite_Collection internal_Ajustement_EssenceUnite_Col_Code_Collection = null;
		public Ajustement_EssenceUnite_Collection Ajustement_EssenceUnite_Col_Code_Collection {

			get {

				if (this.internal_Ajustement_EssenceUnite_Col_Code_Collection == null) {

					this.internal_Ajustement_EssenceUnite_Col_Code_Collection = new Ajustement_EssenceUnite_Collection(this.connectionString);
					this.internal_Ajustement_EssenceUnite_Col_Code_Collection.LoadFrom_Code(this.col_Code, this);
				}

				return(this.internal_Ajustement_EssenceUnite_Col_Code_Collection);
			}
		}

		private Indexation_EssenceUnite_Collection internal_Indexation_EssenceUnite_Col_ContratID_Collection = null;
		public Indexation_EssenceUnite_Collection Indexation_EssenceUnite_Col_ContratID_Collection {

			get {

				if (this.internal_Indexation_EssenceUnite_Col_ContratID_Collection == null) {

					this.internal_Indexation_EssenceUnite_Col_ContratID_Collection = new Indexation_EssenceUnite_Collection(this.connectionString);
					this.internal_Indexation_EssenceUnite_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ContratID, this);
				}

				return(this.internal_Indexation_EssenceUnite_Col_ContratID_Collection);
			}
		}

		private Indexation_EssenceUnite_Collection internal_Indexation_EssenceUnite_Col_EssenceID_Collection = null;
		public Indexation_EssenceUnite_Collection Indexation_EssenceUnite_Col_EssenceID_Collection {

			get {

				if (this.internal_Indexation_EssenceUnite_Col_EssenceID_Collection == null) {

					this.internal_Indexation_EssenceUnite_Col_EssenceID_Collection = new Indexation_EssenceUnite_Collection(this.connectionString);
					this.internal_Indexation_EssenceUnite_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_EssenceID, this);
				}

				return(this.internal_Indexation_EssenceUnite_Col_EssenceID_Collection);
			}
		}

		private Indexation_EssenceUnite_Collection internal_Indexation_EssenceUnite_Col_Code_Collection = null;
		public Indexation_EssenceUnite_Collection Indexation_EssenceUnite_Col_Code_Collection {

			get {

				if (this.internal_Indexation_EssenceUnite_Col_Code_Collection == null) {

					this.internal_Indexation_EssenceUnite_Col_Code_Collection = new Indexation_EssenceUnite_Collection(this.connectionString);
					this.internal_Indexation_EssenceUnite_Col_Code_Collection.LoadFrom_Code(this.col_Code, this);
				}

				return(this.internal_Indexation_EssenceUnite_Col_Code_Collection);
			}
		}

		private Indexation_EssenceUnite_Collection internal_Indexation_EssenceUnite_Col_UniteID_Collection = null;
		public Indexation_EssenceUnite_Collection Indexation_EssenceUnite_Col_UniteID_Collection {

			get {

				if (this.internal_Indexation_EssenceUnite_Col_UniteID_Collection == null) {

					this.internal_Indexation_EssenceUnite_Col_UniteID_Collection = new Indexation_EssenceUnite_Collection(this.connectionString);
					this.internal_Indexation_EssenceUnite_Col_UniteID_Collection.LoadFrom_UniteID(this.col_UniteID, this);
				}

				return(this.internal_Indexation_EssenceUnite_Col_UniteID_Collection);
			}
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_ContratID_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_ContratID_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_ContratID_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_ContratID_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ContratID, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_ContratID_Collection);
			}
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_EssenceID_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_EssenceID_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_EssenceID_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_EssenceID_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_EssenceID, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_EssenceID_Collection);
			}
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_Code_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_Code_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_Code_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_Code_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_Code_Collection.LoadFrom_Code(this.col_Code, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_Code_Collection);
			}
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_UniteID_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_UniteID_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_UniteID_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_UniteID_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_UniteID_Collection.LoadFrom_UniteID(this.col_UniteID, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_UniteID_Collection);
			}
		}

		private Livraison_Detail_Collection internal_Livraison_Detail_Col_ContratID_Collection = null;
		public Livraison_Detail_Collection Livraison_Detail_Col_ContratID_Collection {

			get {

				if (this.internal_Livraison_Detail_Col_ContratID_Collection == null) {

					this.internal_Livraison_Detail_Col_ContratID_Collection = new Livraison_Detail_Collection(this.connectionString);
					this.internal_Livraison_Detail_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ContratID, this);
				}

				return(this.internal_Livraison_Detail_Col_ContratID_Collection);
			}
		}

		private Livraison_Detail_Collection internal_Livraison_Detail_Col_EssenceID_Collection = null;
		public Livraison_Detail_Collection Livraison_Detail_Col_EssenceID_Collection {

			get {

				if (this.internal_Livraison_Detail_Col_EssenceID_Collection == null) {

					this.internal_Livraison_Detail_Col_EssenceID_Collection = new Livraison_Detail_Collection(this.connectionString);
					this.internal_Livraison_Detail_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_EssenceID, this);
				}

				return(this.internal_Livraison_Detail_Col_EssenceID_Collection);
			}
		}

		private Livraison_Detail_Collection internal_Livraison_Detail_Col_UniteMesureID_Collection = null;
		public Livraison_Detail_Collection Livraison_Detail_Col_UniteMesureID_Collection {

			get {

				if (this.internal_Livraison_Detail_Col_UniteMesureID_Collection == null) {

					this.internal_Livraison_Detail_Col_UniteMesureID_Collection = new Livraison_Detail_Collection(this.connectionString);
					this.internal_Livraison_Detail_Col_UniteMesureID_Collection.LoadFrom_UniteMesureID(this.col_UniteID, this);
				}

				return(this.internal_Livraison_Detail_Col_UniteMesureID_Collection);
			}
		}

		private Livraison_Detail_Collection internal_Livraison_Detail_Col_Code_Collection = null;
		public Livraison_Detail_Collection Livraison_Detail_Col_Code_Collection {

			get {

				if (this.internal_Livraison_Detail_Col_Code_Collection == null) {

					this.internal_Livraison_Detail_Col_Code_Collection = new Livraison_Detail_Collection(this.connectionString);
					this.internal_Livraison_Detail_Col_Code_Collection.LoadFrom_Code(this.col_Code, this);
				}

				return(this.internal_Livraison_Detail_Col_Code_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Contrat_EssenceUnite_Display Param = new Params.spS_Contrat_EssenceUnite_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_UniteID = this.col_UniteID;
				Param.Param_Code = this.col_Code;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Contrat_EssenceUnite_Display Sp = new SPs.spS_Contrat_EssenceUnite_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_EssenceUnite_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Contrat_EssenceUnite_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_EssenceUnite_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
