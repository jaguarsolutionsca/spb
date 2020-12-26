using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Compte] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Compte_Collection"/> class to do so.
	/// </summary>
	public sealed class Compte_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Compte_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Compte_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Compte_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Compte_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Compte'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Compte", CurrentRevision, OriginalRevision));
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

		internal bool col_CategoryIDWasSet = false;
		private bool col_CategoryIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_CategoryID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_CategoryID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_CategoryID);
			}
			set {
			
				this.col_CategoryIDWasUpdated = true;
				this.col_CategoryIDWasSet = true;
				this.col_CategoryID_Record = null;
				this.col_CategoryID = value;
			}
		}

		
		private CompteCategory_Record col_CategoryID_Record = null;
		public CompteCategory_Record Col_CategoryID_CompteCategory_Record {
		
			get {

				if (this.col_CategoryID_Record == null) {
				
					this.col_CategoryID_Record = new CompteCategory_Record(this.connectionString, this.col_CategoryID);
				}
				
				return(this.col_CategoryID_Record);
			}
		}

		internal bool col_isTaxeWasSet = false;
		private bool col_isTaxeWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_isTaxe = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_isTaxe {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_isTaxe);
			}
			set {
			
				this.col_isTaxeWasUpdated = true;
				this.col_isTaxeWasSet = true;
				this.col_isTaxe = value;
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


		public bool Refresh() {

			this.displayName = null;

			this.col_DescriptionWasUpdated = false;
			this.col_DescriptionWasSet = false;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;

			this.col_CategoryIDWasUpdated = false;
			this.col_CategoryIDWasSet = false;
			this.col_CategoryID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_isTaxeWasUpdated = false;
			this.col_isTaxeWasSet = false;
			this.col_isTaxe = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Compte Param = new Params.spS_Compte(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Compte Sp = new SPs.spS_Compte();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Compte.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_Compte.Resultset1.Fields.Column_Description.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Compte.Resultset1.Fields.Column_CategoryID.ColumnIndex)) {

						this.col_CategoryID = sqlDataReader.GetSqlInt32(SPs.spS_Compte.Resultset1.Fields.Column_CategoryID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Compte.Resultset1.Fields.Column_isTaxe.ColumnIndex)) {

						this.col_isTaxe = sqlDataReader.GetSqlBoolean(SPs.spS_Compte.Resultset1.Fields.Column_isTaxe.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Compte.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Compte.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Compte_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CategoryIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_isTaxeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Compte Param = new Params.spU_Compte(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			if (this.col_CategoryIDWasUpdated) {

				Param.Param_CategoryID = this.col_CategoryID;
				Param.Param_ConsiderNull_CategoryID = true;
			}

			if (this.col_isTaxeWasUpdated) {

				Param.Param_isTaxe = this.col_isTaxe;
				Param.Param_ConsiderNull_isTaxe = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			SPs.spU_Compte Sp = new SPs.spU_Compte();
			if (Sp.Execute(ref Param)) {

				this.col_DescriptionWasUpdated = false;
				this.col_CategoryIDWasUpdated = false;
				this.col_isTaxeWasUpdated = false;
				this.col_ActifWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Compte_Record", "Update");
			}		
		}

		private FactureClient_Details_Collection internal_FactureClient_Details_Col_Compte_Collection = null;
		public FactureClient_Details_Collection FactureClient_Details_Col_Compte_Collection {

			get {

				if (this.internal_FactureClient_Details_Col_Compte_Collection == null) {

					this.internal_FactureClient_Details_Col_Compte_Collection = new FactureClient_Details_Collection(this.connectionString);
					this.internal_FactureClient_Details_Col_Compte_Collection.LoadFrom_Compte(this.col_ID, this);
				}

				return(this.internal_FactureClient_Details_Col_Compte_Collection);
			}
		}

		private FactureClient_Sommaire_Collection internal_FactureClient_Sommaire_Col_Compte_Collection = null;
		public FactureClient_Sommaire_Collection FactureClient_Sommaire_Col_Compte_Collection {

			get {

				if (this.internal_FactureClient_Sommaire_Col_Compte_Collection == null) {

					this.internal_FactureClient_Sommaire_Col_Compte_Collection = new FactureClient_Sommaire_Collection(this.connectionString);
					this.internal_FactureClient_Sommaire_Col_Compte_Collection.LoadFrom_Compte(this.col_ID, this);
				}

				return(this.internal_FactureClient_Sommaire_Col_Compte_Collection);
			}
		}

		private FactureFournisseur_Details_Collection internal_FactureFournisseur_Details_Col_Compte_Collection = null;
		public FactureFournisseur_Details_Collection FactureFournisseur_Details_Col_Compte_Collection {

			get {

				if (this.internal_FactureFournisseur_Details_Col_Compte_Collection == null) {

					this.internal_FactureFournisseur_Details_Col_Compte_Collection = new FactureFournisseur_Details_Collection(this.connectionString);
					this.internal_FactureFournisseur_Details_Col_Compte_Collection.LoadFrom_Compte(this.col_ID, this);
				}

				return(this.internal_FactureFournisseur_Details_Col_Compte_Collection);
			}
		}

		private FactureFournisseur_Sommaire_Collection internal_FactureFournisseur_Sommaire_Col_Compte_Collection = null;
		public FactureFournisseur_Sommaire_Collection FactureFournisseur_Sommaire_Col_Compte_Collection {

			get {

				if (this.internal_FactureFournisseur_Sommaire_Col_Compte_Collection == null) {

					this.internal_FactureFournisseur_Sommaire_Col_Compte_Collection = new FactureFournisseur_Sommaire_Collection(this.connectionString);
					this.internal_FactureFournisseur_Sommaire_Col_Compte_Collection.LoadFrom_Compte(this.col_ID, this);
				}

				return(this.internal_FactureFournisseur_Sommaire_Col_Compte_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_a_recevoir_Collection = null;
		public Usine_Collection Usine_Col_Compte_a_recevoir_Collection {

			get {

				if (this.internal_Usine_Col_Compte_a_recevoir_Collection == null) {

					this.internal_Usine_Col_Compte_a_recevoir_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_a_recevoir_Collection.LoadFrom_Compte_a_recevoir(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_a_recevoir_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_ajustement_Collection = null;
		public Usine_Collection Usine_Col_Compte_ajustement_Collection {

			get {

				if (this.internal_Usine_Col_Compte_ajustement_Collection == null) {

					this.internal_Usine_Col_Compte_ajustement_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_ajustement_Collection.LoadFrom_Compte_ajustement(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_ajustement_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_transporteur_Collection = null;
		public Usine_Collection Usine_Col_Compte_transporteur_Collection {

			get {

				if (this.internal_Usine_Col_Compte_transporteur_Collection == null) {

					this.internal_Usine_Col_Compte_transporteur_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_transporteur_Collection.LoadFrom_Compte_transporteur(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_transporteur_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_producteur_Collection = null;
		public Usine_Collection Usine_Col_Compte_producteur_Collection {

			get {

				if (this.internal_Usine_Col_Compte_producteur_Collection == null) {

					this.internal_Usine_Col_Compte_producteur_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_producteur_Collection.LoadFrom_Compte_producteur(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_producteur_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_preleve_plan_conjoint_Collection = null;
		public Usine_Collection Usine_Col_Compte_preleve_plan_conjoint_Collection {

			get {

				if (this.internal_Usine_Col_Compte_preleve_plan_conjoint_Collection == null) {

					this.internal_Usine_Col_Compte_preleve_plan_conjoint_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_preleve_plan_conjoint_Collection.LoadFrom_Compte_preleve_plan_conjoint(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_preleve_plan_conjoint_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_preleve_fond_roulement_Collection = null;
		public Usine_Collection Usine_Col_Compte_preleve_fond_roulement_Collection {

			get {

				if (this.internal_Usine_Col_Compte_preleve_fond_roulement_Collection == null) {

					this.internal_Usine_Col_Compte_preleve_fond_roulement_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_preleve_fond_roulement_Collection.LoadFrom_Compte_preleve_fond_roulement(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_preleve_fond_roulement_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_preleve_fond_forestier_Collection = null;
		public Usine_Collection Usine_Col_Compte_preleve_fond_forestier_Collection {

			get {

				if (this.internal_Usine_Col_Compte_preleve_fond_forestier_Collection == null) {

					this.internal_Usine_Col_Compte_preleve_fond_forestier_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_preleve_fond_forestier_Collection.LoadFrom_Compte_preleve_fond_forestier(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_preleve_fond_forestier_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_preleve_divers_Collection = null;
		public Usine_Collection Usine_Col_Compte_preleve_divers_Collection {

			get {

				if (this.internal_Usine_Col_Compte_preleve_divers_Collection == null) {

					this.internal_Usine_Col_Compte_preleve_divers_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_preleve_divers_Collection.LoadFrom_Compte_preleve_divers(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_preleve_divers_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_mise_en_commun_Collection = null;
		public Usine_Collection Usine_Col_Compte_mise_en_commun_Collection {

			get {

				if (this.internal_Usine_Col_Compte_mise_en_commun_Collection == null) {

					this.internal_Usine_Col_Compte_mise_en_commun_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_mise_en_commun_Collection.LoadFrom_Compte_mise_en_commun(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_mise_en_commun_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_surcharge_Collection = null;
		public Usine_Collection Usine_Col_Compte_surcharge_Collection {

			get {

				if (this.internal_Usine_Col_Compte_surcharge_Collection == null) {

					this.internal_Usine_Col_Compte_surcharge_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_surcharge_Collection.LoadFrom_Compte_surcharge(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_surcharge_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_Compte_indexation_carburant_Collection = null;
		public Usine_Collection Usine_Col_Compte_indexation_carburant_Collection {

			get {

				if (this.internal_Usine_Col_Compte_indexation_carburant_Collection == null) {

					this.internal_Usine_Col_Compte_indexation_carburant_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_Compte_indexation_carburant_Collection.LoadFrom_Compte_indexation_carburant(this.col_ID, this);
				}

				return(this.internal_Usine_Col_Compte_indexation_carburant_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Compte_Display Param = new Params.spS_Compte_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Compte_Display Sp = new SPs.spS_Compte_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Compte_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Compte_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Compte_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
