using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Essence_Unite] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Essence_Unite_Collection"/> class to do so.
	/// </summary>
	public sealed class Essence_Unite_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Essence_Unite_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Essence_Unite_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Essence_Unite_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_UniteID">[To be supplied.]</param>
		public Essence_Unite_Record(string connectionString, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Essence_Unite'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Essence_Unite", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_EssenceID = col_EssenceID;
			this.col_UniteID = col_UniteID;
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
		
		
		private Essence_Record col_EssenceID_Record = null;
		public Essence_Record Col_EssenceID_Essence_Record {
		
			get {

				if (this.col_EssenceID_Record == null) {
				
					this.col_EssenceID_Record = new Essence_Record(this.connectionString, this.col_EssenceID);
				}
				
				return(this.col_EssenceID_Record);
			}
		}

		
		private UniteMesure_Record col_UniteID_Record = null;
		public UniteMesure_Record Col_UniteID_UniteMesure_Record {
		
			get {

				if (this.col_UniteID_Record == null) {
				
					this.col_UniteID_Record = new UniteMesure_Record(this.connectionString, this.col_UniteID);
				}
				
				return(this.col_UniteID_Record);
			}
		}

		internal bool col_Facteur_M3appWasSet = false;
		private bool col_Facteur_M3appWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Facteur_M3app = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Facteur_M3app {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Facteur_M3app);
			}
			set {
			
				this.col_Facteur_M3appWasUpdated = true;
				this.col_Facteur_M3appWasSet = true;
				this.col_Facteur_M3app = value;
			}
		}

		internal bool col_Facteur_M3solWasSet = false;
		private bool col_Facteur_M3solWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Facteur_M3sol = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Facteur_M3sol {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Facteur_M3sol);
			}
			set {
			
				this.col_Facteur_M3solWasUpdated = true;
				this.col_Facteur_M3solWasSet = true;
				this.col_Facteur_M3sol = value;
			}
		}

		internal bool col_Facteur_FPBQWasSet = false;
		private bool col_Facteur_FPBQWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Facteur_FPBQ = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Facteur_FPBQ {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Facteur_FPBQ);
			}
			set {
			
				this.col_Facteur_FPBQWasUpdated = true;
				this.col_Facteur_FPBQWasSet = true;
				this.col_Facteur_FPBQ = value;
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

		internal bool col_Preleve_plan_conjointWasSet = false;
		private bool col_Preleve_plan_conjointWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Preleve_plan_conjoint = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Preleve_plan_conjoint {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Preleve_plan_conjoint);
			}
			set {
			
				this.col_Preleve_plan_conjointWasUpdated = true;
				this.col_Preleve_plan_conjointWasSet = true;
				this.col_Preleve_plan_conjoint = value;
			}
		}

		internal bool col_Preleve_plan_conjoint_OverrideWasSet = false;
		private bool col_Preleve_plan_conjoint_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Preleve_plan_conjoint_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Preleve_plan_conjoint_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Preleve_plan_conjoint_Override);
			}
			set {
			
				this.col_Preleve_plan_conjoint_OverrideWasUpdated = true;
				this.col_Preleve_plan_conjoint_OverrideWasSet = true;
				this.col_Preleve_plan_conjoint_Override = value;
			}
		}

		internal bool col_Preleve_fond_roulementWasSet = false;
		private bool col_Preleve_fond_roulementWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Preleve_fond_roulement = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Preleve_fond_roulement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Preleve_fond_roulement);
			}
			set {
			
				this.col_Preleve_fond_roulementWasUpdated = true;
				this.col_Preleve_fond_roulementWasSet = true;
				this.col_Preleve_fond_roulement = value;
			}
		}

		internal bool col_Preleve_fond_roulement_OverrideWasSet = false;
		private bool col_Preleve_fond_roulement_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Preleve_fond_roulement_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Preleve_fond_roulement_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Preleve_fond_roulement_Override);
			}
			set {
			
				this.col_Preleve_fond_roulement_OverrideWasUpdated = true;
				this.col_Preleve_fond_roulement_OverrideWasSet = true;
				this.col_Preleve_fond_roulement_Override = value;
			}
		}

		internal bool col_Preleve_fond_forestierWasSet = false;
		private bool col_Preleve_fond_forestierWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Preleve_fond_forestier = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Preleve_fond_forestier {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Preleve_fond_forestier);
			}
			set {
			
				this.col_Preleve_fond_forestierWasUpdated = true;
				this.col_Preleve_fond_forestierWasSet = true;
				this.col_Preleve_fond_forestier = value;
			}
		}

		internal bool col_Preleve_fond_forestier_OverrideWasSet = false;
		private bool col_Preleve_fond_forestier_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Preleve_fond_forestier_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Preleve_fond_forestier_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Preleve_fond_forestier_Override);
			}
			set {
			
				this.col_Preleve_fond_forestier_OverrideWasUpdated = true;
				this.col_Preleve_fond_forestier_OverrideWasSet = true;
				this.col_Preleve_fond_forestier_Override = value;
			}
		}

		internal bool col_Preleve_diversWasSet = false;
		private bool col_Preleve_diversWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Preleve_divers = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Preleve_divers {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Preleve_divers);
			}
			set {
			
				this.col_Preleve_diversWasUpdated = true;
				this.col_Preleve_diversWasSet = true;
				this.col_Preleve_divers = value;
			}
		}

		internal bool col_Preleve_divers_OverrideWasSet = false;
		private bool col_Preleve_divers_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Preleve_divers_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Preleve_divers_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Preleve_divers_Override);
			}
			set {
			
				this.col_Preleve_divers_OverrideWasUpdated = true;
				this.col_Preleve_divers_OverrideWasSet = true;
				this.col_Preleve_divers_Override = value;
			}
		}

		internal bool col_UseMontantWasSet = false;
		private bool col_UseMontantWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_UseMontant = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_UseMontant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UseMontant);
			}
			set {
			
				this.col_UseMontantWasUpdated = true;
				this.col_UseMontantWasSet = true;
				this.col_UseMontant = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_Facteur_M3appWasUpdated = false;
			this.col_Facteur_M3appWasSet = false;
			this.col_Facteur_M3app = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Facteur_M3solWasUpdated = false;
			this.col_Facteur_M3solWasSet = false;
			this.col_Facteur_M3sol = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Facteur_FPBQWasUpdated = false;
			this.col_Facteur_FPBQWasSet = false;
			this.col_Facteur_FPBQ = System.Data.SqlTypes.SqlSingle.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Preleve_plan_conjointWasUpdated = false;
			this.col_Preleve_plan_conjointWasSet = false;
			this.col_Preleve_plan_conjoint = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Preleve_plan_conjoint_OverrideWasUpdated = false;
			this.col_Preleve_plan_conjoint_OverrideWasSet = false;
			this.col_Preleve_plan_conjoint_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Preleve_fond_roulementWasUpdated = false;
			this.col_Preleve_fond_roulementWasSet = false;
			this.col_Preleve_fond_roulement = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Preleve_fond_roulement_OverrideWasUpdated = false;
			this.col_Preleve_fond_roulement_OverrideWasSet = false;
			this.col_Preleve_fond_roulement_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Preleve_fond_forestierWasUpdated = false;
			this.col_Preleve_fond_forestierWasSet = false;
			this.col_Preleve_fond_forestier = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Preleve_fond_forestier_OverrideWasUpdated = false;
			this.col_Preleve_fond_forestier_OverrideWasSet = false;
			this.col_Preleve_fond_forestier_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Preleve_diversWasUpdated = false;
			this.col_Preleve_diversWasSet = false;
			this.col_Preleve_divers = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Preleve_divers_OverrideWasUpdated = false;
			this.col_Preleve_divers_OverrideWasSet = false;
			this.col_Preleve_divers_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_UseMontantWasUpdated = false;
			this.col_UseMontantWasSet = false;
			this.col_UseMontant = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Essence_Unite Param = new Params.spS_Essence_Unite(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_UniteID.IsNull) {

				Param.Param_UniteID = this.col_UniteID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Essence_Unite Sp = new SPs.spS_Essence_Unite();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_M3app.ColumnIndex)) {

						this.col_Facteur_M3app = sqlDataReader.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_M3app.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_M3sol.ColumnIndex)) {

						this.col_Facteur_M3sol = sqlDataReader.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_M3sol.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_FPBQ.ColumnIndex)) {

						this.col_Facteur_FPBQ = sqlDataReader.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Facteur_FPBQ.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Actif.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_plan_conjoint.ColumnIndex)) {

						this.col_Preleve_plan_conjoint = sqlDataReader.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_plan_conjoint.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_plan_conjoint_Override.ColumnIndex)) {

						this.col_Preleve_plan_conjoint_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_plan_conjoint_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_roulement.ColumnIndex)) {

						this.col_Preleve_fond_roulement = sqlDataReader.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_roulement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_roulement_Override.ColumnIndex)) {

						this.col_Preleve_fond_roulement_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_roulement_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_forestier.ColumnIndex)) {

						this.col_Preleve_fond_forestier = sqlDataReader.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_forestier.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_forestier_Override.ColumnIndex)) {

						this.col_Preleve_fond_forestier_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_fond_forestier_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_divers.ColumnIndex)) {

						this.col_Preleve_divers = sqlDataReader.GetSqlSingle(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_divers.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_divers_Override.ColumnIndex)) {

						this.col_Preleve_divers_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_Preleve_divers_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite.Resultset1.Fields.Column_UseMontant.ColumnIndex)) {

						this.col_UseMontant = sqlDataReader.GetSqlBoolean(SPs.spS_Essence_Unite.Resultset1.Fields.Column_UseMontant.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Essence_Unite_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Facteur_M3appWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Facteur_M3solWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Facteur_FPBQWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Preleve_plan_conjointWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Preleve_plan_conjoint_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Preleve_fond_roulementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Preleve_fond_roulement_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Preleve_fond_forestierWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Preleve_fond_forestier_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Preleve_diversWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Preleve_divers_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UseMontantWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Essence_Unite Param = new Params.spU_Essence_Unite(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_EssenceID = this.col_EssenceID;
			Param.Param_UniteID = this.col_UniteID;

			if (this.col_Facteur_M3appWasUpdated) {

				Param.Param_Facteur_M3app = this.col_Facteur_M3app;
				Param.Param_ConsiderNull_Facteur_M3app = true;
			}

			if (this.col_Facteur_M3solWasUpdated) {

				Param.Param_Facteur_M3sol = this.col_Facteur_M3sol;
				Param.Param_ConsiderNull_Facteur_M3sol = true;
			}

			if (this.col_Facteur_FPBQWasUpdated) {

				Param.Param_Facteur_FPBQ = this.col_Facteur_FPBQ;
				Param.Param_ConsiderNull_Facteur_FPBQ = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			if (this.col_Preleve_plan_conjointWasUpdated) {

				Param.Param_Preleve_plan_conjoint = this.col_Preleve_plan_conjoint;
				Param.Param_ConsiderNull_Preleve_plan_conjoint = true;
			}

			if (this.col_Preleve_plan_conjoint_OverrideWasUpdated) {

				Param.Param_Preleve_plan_conjoint_Override = this.col_Preleve_plan_conjoint_Override;
				Param.Param_ConsiderNull_Preleve_plan_conjoint_Override = true;
			}

			if (this.col_Preleve_fond_roulementWasUpdated) {

				Param.Param_Preleve_fond_roulement = this.col_Preleve_fond_roulement;
				Param.Param_ConsiderNull_Preleve_fond_roulement = true;
			}

			if (this.col_Preleve_fond_roulement_OverrideWasUpdated) {

				Param.Param_Preleve_fond_roulement_Override = this.col_Preleve_fond_roulement_Override;
				Param.Param_ConsiderNull_Preleve_fond_roulement_Override = true;
			}

			if (this.col_Preleve_fond_forestierWasUpdated) {

				Param.Param_Preleve_fond_forestier = this.col_Preleve_fond_forestier;
				Param.Param_ConsiderNull_Preleve_fond_forestier = true;
			}

			if (this.col_Preleve_fond_forestier_OverrideWasUpdated) {

				Param.Param_Preleve_fond_forestier_Override = this.col_Preleve_fond_forestier_Override;
				Param.Param_ConsiderNull_Preleve_fond_forestier_Override = true;
			}

			if (this.col_Preleve_diversWasUpdated) {

				Param.Param_Preleve_divers = this.col_Preleve_divers;
				Param.Param_ConsiderNull_Preleve_divers = true;
			}

			if (this.col_Preleve_divers_OverrideWasUpdated) {

				Param.Param_Preleve_divers_Override = this.col_Preleve_divers_Override;
				Param.Param_ConsiderNull_Preleve_divers_Override = true;
			}

			if (this.col_UseMontantWasUpdated) {

				Param.Param_UseMontant = this.col_UseMontant;
				Param.Param_ConsiderNull_UseMontant = true;
			}

			SPs.spU_Essence_Unite Sp = new SPs.spU_Essence_Unite();
			if (Sp.Execute(ref Param)) {

				this.col_Facteur_M3appWasUpdated = false;
				this.col_Facteur_M3solWasUpdated = false;
				this.col_Facteur_FPBQWasUpdated = false;
				this.col_ActifWasUpdated = false;
				this.col_Preleve_plan_conjointWasUpdated = false;
				this.col_Preleve_plan_conjoint_OverrideWasUpdated = false;
				this.col_Preleve_fond_roulementWasUpdated = false;
				this.col_Preleve_fond_roulement_OverrideWasUpdated = false;
				this.col_Preleve_fond_forestierWasUpdated = false;
				this.col_Preleve_fond_forestier_OverrideWasUpdated = false;
				this.col_Preleve_diversWasUpdated = false;
				this.col_Preleve_divers_OverrideWasUpdated = false;
				this.col_UseMontantWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Essence_Unite_Record", "Update");
			}		
		}

		private Contrat_EssenceUnite_Collection internal_Contrat_EssenceUnite_Col_EssenceID_Collection = null;
		public Contrat_EssenceUnite_Collection Contrat_EssenceUnite_Col_EssenceID_Collection {

			get {

				if (this.internal_Contrat_EssenceUnite_Col_EssenceID_Collection == null) {

					this.internal_Contrat_EssenceUnite_Col_EssenceID_Collection = new Contrat_EssenceUnite_Collection(this.connectionString);
					this.internal_Contrat_EssenceUnite_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_EssenceID, this);
				}

				return(this.internal_Contrat_EssenceUnite_Col_EssenceID_Collection);
			}
		}

		private Contrat_EssenceUnite_Collection internal_Contrat_EssenceUnite_Col_UniteID_Collection = null;
		public Contrat_EssenceUnite_Collection Contrat_EssenceUnite_Col_UniteID_Collection {

			get {

				if (this.internal_Contrat_EssenceUnite_Col_UniteID_Collection == null) {

					this.internal_Contrat_EssenceUnite_Col_UniteID_Collection = new Contrat_EssenceUnite_Collection(this.connectionString);
					this.internal_Contrat_EssenceUnite_Col_UniteID_Collection.LoadFrom_UniteID(this.col_UniteID, this);
				}

				return(this.internal_Contrat_EssenceUnite_Col_UniteID_Collection);
			}
		}

		private GestionVolume_Detail_Collection internal_GestionVolume_Detail_Col_EssenceID_Collection = null;
		public GestionVolume_Detail_Collection GestionVolume_Detail_Col_EssenceID_Collection {

			get {

				if (this.internal_GestionVolume_Detail_Col_EssenceID_Collection == null) {

					this.internal_GestionVolume_Detail_Col_EssenceID_Collection = new GestionVolume_Detail_Collection(this.connectionString);
					this.internal_GestionVolume_Detail_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_EssenceID, this);
				}

				return(this.internal_GestionVolume_Detail_Col_EssenceID_Collection);
			}
		}

		private GestionVolume_Detail_Collection internal_GestionVolume_Detail_Col_UniteMesureID_Collection = null;
		public GestionVolume_Detail_Collection GestionVolume_Detail_Col_UniteMesureID_Collection {

			get {

				if (this.internal_GestionVolume_Detail_Col_UniteMesureID_Collection == null) {

					this.internal_GestionVolume_Detail_Col_UniteMesureID_Collection = new GestionVolume_Detail_Collection(this.connectionString);
					this.internal_GestionVolume_Detail_Col_UniteMesureID_Collection.LoadFrom_UniteMesureID(this.col_UniteID, this);
				}

				return(this.internal_GestionVolume_Detail_Col_UniteMesureID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Essence_Unite_Display Param = new Params.spS_Essence_Unite_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_UniteID = this.col_UniteID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Essence_Unite_Display Sp = new SPs.spS_Essence_Unite_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Essence_Unite_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Essence_Unite_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Essence_Unite_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
