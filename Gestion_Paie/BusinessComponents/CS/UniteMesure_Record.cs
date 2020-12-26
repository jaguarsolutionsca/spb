using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [UniteMesure] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.UniteMesure_Collection"/> class to do so.
	/// </summary>
	public sealed class UniteMesure_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the UniteMesure_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.UniteMesure_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public UniteMesure_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public UniteMesure_Record(string connectionString, System.Data.SqlTypes.SqlString col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'UniteMesure'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "UniteMesure", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlString col_ID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ID {
		
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

		internal bool col_Nb_decimaleWasSet = false;
		private bool col_Nb_decimaleWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Nb_decimale = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Nb_decimale {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Nb_decimale);
			}
			set {
			
				this.col_Nb_decimaleWasUpdated = true;
				this.col_Nb_decimaleWasSet = true;
				this.col_Nb_decimale = value;
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

		internal bool col_Montant_Preleve_plan_conjointWasSet = false;
		private bool col_Montant_Preleve_plan_conjointWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Preleve_plan_conjoint = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_plan_conjoint {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Preleve_plan_conjoint);
			}
			set {
			
				this.col_Montant_Preleve_plan_conjointWasUpdated = true;
				this.col_Montant_Preleve_plan_conjointWasSet = true;
				this.col_Montant_Preleve_plan_conjoint = value;
			}
		}

		internal bool col_Montant_Preleve_fond_roulementWasSet = false;
		private bool col_Montant_Preleve_fond_roulementWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Preleve_fond_roulement = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_fond_roulement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Preleve_fond_roulement);
			}
			set {
			
				this.col_Montant_Preleve_fond_roulementWasUpdated = true;
				this.col_Montant_Preleve_fond_roulementWasSet = true;
				this.col_Montant_Preleve_fond_roulement = value;
			}
		}

		internal bool col_Montant_Preleve_fond_forestierWasSet = false;
		private bool col_Montant_Preleve_fond_forestierWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Preleve_fond_forestier = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_fond_forestier {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Preleve_fond_forestier);
			}
			set {
			
				this.col_Montant_Preleve_fond_forestierWasUpdated = true;
				this.col_Montant_Preleve_fond_forestierWasSet = true;
				this.col_Montant_Preleve_fond_forestier = value;
			}
		}

		internal bool col_Montant_Preleve_diversWasSet = false;
		private bool col_Montant_Preleve_diversWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Preleve_divers = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_divers {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Preleve_divers);
			}
			set {
			
				this.col_Montant_Preleve_diversWasUpdated = true;
				this.col_Montant_Preleve_diversWasSet = true;
				this.col_Montant_Preleve_divers = value;
			}
		}

		internal bool col_Pourc_Preleve_plan_conjointWasSet = false;
		private bool col_Pourc_Preleve_plan_conjointWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Pourc_Preleve_plan_conjoint = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Pourc_Preleve_plan_conjoint {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Pourc_Preleve_plan_conjoint);
			}
			set {
			
				this.col_Pourc_Preleve_plan_conjointWasUpdated = true;
				this.col_Pourc_Preleve_plan_conjointWasSet = true;
				this.col_Pourc_Preleve_plan_conjoint = value;
			}
		}

		internal bool col_Pourc_Preleve_fond_roulementWasSet = false;
		private bool col_Pourc_Preleve_fond_roulementWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Pourc_Preleve_fond_roulement = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Pourc_Preleve_fond_roulement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Pourc_Preleve_fond_roulement);
			}
			set {
			
				this.col_Pourc_Preleve_fond_roulementWasUpdated = true;
				this.col_Pourc_Preleve_fond_roulementWasSet = true;
				this.col_Pourc_Preleve_fond_roulement = value;
			}
		}

		internal bool col_Pourc_Preleve_fond_forestierWasSet = false;
		private bool col_Pourc_Preleve_fond_forestierWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Pourc_Preleve_fond_forestier = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Pourc_Preleve_fond_forestier {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Pourc_Preleve_fond_forestier);
			}
			set {
			
				this.col_Pourc_Preleve_fond_forestierWasUpdated = true;
				this.col_Pourc_Preleve_fond_forestierWasSet = true;
				this.col_Pourc_Preleve_fond_forestier = value;
			}
		}

		internal bool col_Pourc_Preleve_diversWasSet = false;
		private bool col_Pourc_Preleve_diversWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Pourc_Preleve_divers = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Pourc_Preleve_divers {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Pourc_Preleve_divers);
			}
			set {
			
				this.col_Pourc_Preleve_diversWasUpdated = true;
				this.col_Pourc_Preleve_diversWasSet = true;
				this.col_Pourc_Preleve_divers = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_DescriptionWasUpdated = false;
			this.col_DescriptionWasSet = false;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;

			this.col_Nb_decimaleWasUpdated = false;
			this.col_Nb_decimaleWasSet = false;
			this.col_Nb_decimale = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_UseMontantWasUpdated = false;
			this.col_UseMontantWasSet = false;
			this.col_UseMontant = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Montant_Preleve_plan_conjointWasUpdated = false;
			this.col_Montant_Preleve_plan_conjointWasSet = false;
			this.col_Montant_Preleve_plan_conjoint = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_fond_roulementWasUpdated = false;
			this.col_Montant_Preleve_fond_roulementWasSet = false;
			this.col_Montant_Preleve_fond_roulement = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_fond_forestierWasUpdated = false;
			this.col_Montant_Preleve_fond_forestierWasSet = false;
			this.col_Montant_Preleve_fond_forestier = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_diversWasUpdated = false;
			this.col_Montant_Preleve_diversWasSet = false;
			this.col_Montant_Preleve_divers = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Pourc_Preleve_plan_conjointWasUpdated = false;
			this.col_Pourc_Preleve_plan_conjointWasSet = false;
			this.col_Pourc_Preleve_plan_conjoint = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Pourc_Preleve_fond_roulementWasUpdated = false;
			this.col_Pourc_Preleve_fond_roulementWasSet = false;
			this.col_Pourc_Preleve_fond_roulement = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Pourc_Preleve_fond_forestierWasUpdated = false;
			this.col_Pourc_Preleve_fond_forestierWasSet = false;
			this.col_Pourc_Preleve_fond_forestier = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Pourc_Preleve_diversWasUpdated = false;
			this.col_Pourc_Preleve_diversWasSet = false;
			this.col_Pourc_Preleve_divers = System.Data.SqlTypes.SqlDouble.Null;

			Params.spS_UniteMesure Param = new Params.spS_UniteMesure(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_UniteMesure Sp = new SPs.spS_UniteMesure();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_UniteMesure.Resultset1.Fields.Column_Description.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Nb_decimale.ColumnIndex)) {

						this.col_Nb_decimale = sqlDataReader.GetSqlInt32(SPs.spS_UniteMesure.Resultset1.Fields.Column_Nb_decimale.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_UniteMesure.Resultset1.Fields.Column_Actif.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_UseMontant.ColumnIndex)) {

						this.col_UseMontant = sqlDataReader.GetSqlBoolean(SPs.spS_UniteMesure.Resultset1.Fields.Column_UseMontant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_plan_conjoint.ColumnIndex)) {

						this.col_Montant_Preleve_plan_conjoint = sqlDataReader.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_plan_conjoint.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_fond_roulement.ColumnIndex)) {

						this.col_Montant_Preleve_fond_roulement = sqlDataReader.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_fond_roulement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_fond_forestier.ColumnIndex)) {

						this.col_Montant_Preleve_fond_forestier = sqlDataReader.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_fond_forestier.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_divers.ColumnIndex)) {

						this.col_Montant_Preleve_divers = sqlDataReader.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Montant_Preleve_divers.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_plan_conjoint.ColumnIndex)) {

						this.col_Pourc_Preleve_plan_conjoint = sqlDataReader.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_plan_conjoint.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_fond_roulement.ColumnIndex)) {

						this.col_Pourc_Preleve_fond_roulement = sqlDataReader.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_fond_roulement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_fond_forestier.ColumnIndex)) {

						this.col_Pourc_Preleve_fond_forestier = sqlDataReader.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_fond_forestier.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_divers.ColumnIndex)) {

						this.col_Pourc_Preleve_divers = sqlDataReader.GetSqlDouble(SPs.spS_UniteMesure.Resultset1.Fields.Column_Pourc_Preleve_divers.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.UniteMesure_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Nb_decimaleWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UseMontantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_plan_conjointWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_fond_roulementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_fond_forestierWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_diversWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Pourc_Preleve_plan_conjointWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Pourc_Preleve_fond_roulementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Pourc_Preleve_fond_forestierWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Pourc_Preleve_diversWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_UniteMesure Param = new Params.spU_UniteMesure(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			if (this.col_Nb_decimaleWasUpdated) {

				Param.Param_Nb_decimale = this.col_Nb_decimale;
				Param.Param_ConsiderNull_Nb_decimale = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			if (this.col_UseMontantWasUpdated) {

				Param.Param_UseMontant = this.col_UseMontant;
				Param.Param_ConsiderNull_UseMontant = true;
			}

			if (this.col_Montant_Preleve_plan_conjointWasUpdated) {

				Param.Param_Montant_Preleve_plan_conjoint = this.col_Montant_Preleve_plan_conjoint;
				Param.Param_ConsiderNull_Montant_Preleve_plan_conjoint = true;
			}

			if (this.col_Montant_Preleve_fond_roulementWasUpdated) {

				Param.Param_Montant_Preleve_fond_roulement = this.col_Montant_Preleve_fond_roulement;
				Param.Param_ConsiderNull_Montant_Preleve_fond_roulement = true;
			}

			if (this.col_Montant_Preleve_fond_forestierWasUpdated) {

				Param.Param_Montant_Preleve_fond_forestier = this.col_Montant_Preleve_fond_forestier;
				Param.Param_ConsiderNull_Montant_Preleve_fond_forestier = true;
			}

			if (this.col_Montant_Preleve_diversWasUpdated) {

				Param.Param_Montant_Preleve_divers = this.col_Montant_Preleve_divers;
				Param.Param_ConsiderNull_Montant_Preleve_divers = true;
			}

			if (this.col_Pourc_Preleve_plan_conjointWasUpdated) {

				Param.Param_Pourc_Preleve_plan_conjoint = this.col_Pourc_Preleve_plan_conjoint;
				Param.Param_ConsiderNull_Pourc_Preleve_plan_conjoint = true;
			}

			if (this.col_Pourc_Preleve_fond_roulementWasUpdated) {

				Param.Param_Pourc_Preleve_fond_roulement = this.col_Pourc_Preleve_fond_roulement;
				Param.Param_ConsiderNull_Pourc_Preleve_fond_roulement = true;
			}

			if (this.col_Pourc_Preleve_fond_forestierWasUpdated) {

				Param.Param_Pourc_Preleve_fond_forestier = this.col_Pourc_Preleve_fond_forestier;
				Param.Param_ConsiderNull_Pourc_Preleve_fond_forestier = true;
			}

			if (this.col_Pourc_Preleve_diversWasUpdated) {

				Param.Param_Pourc_Preleve_divers = this.col_Pourc_Preleve_divers;
				Param.Param_ConsiderNull_Pourc_Preleve_divers = true;
			}

			SPs.spU_UniteMesure Sp = new SPs.spU_UniteMesure();
			if (Sp.Execute(ref Param)) {

				this.col_DescriptionWasUpdated = false;
				this.col_Nb_decimaleWasUpdated = false;
				this.col_ActifWasUpdated = false;
				this.col_UseMontantWasUpdated = false;
				this.col_Montant_Preleve_plan_conjointWasUpdated = false;
				this.col_Montant_Preleve_fond_roulementWasUpdated = false;
				this.col_Montant_Preleve_fond_forestierWasUpdated = false;
				this.col_Montant_Preleve_diversWasUpdated = false;
				this.col_Pourc_Preleve_plan_conjointWasUpdated = false;
				this.col_Pourc_Preleve_fond_roulementWasUpdated = false;
				this.col_Pourc_Preleve_fond_forestierWasUpdated = false;
				this.col_Pourc_Preleve_diversWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.UniteMesure_Record", "Update");
			}		
		}

		private Contingentement_Collection internal_Contingentement_Col_UniteMesureID_Collection = null;
		public Contingentement_Collection Contingentement_Col_UniteMesureID_Collection {

			get {

				if (this.internal_Contingentement_Col_UniteMesureID_Collection == null) {

					this.internal_Contingentement_Col_UniteMesureID_Collection = new Contingentement_Collection(this.connectionString);
					this.internal_Contingentement_Col_UniteMesureID_Collection.LoadFrom_UniteMesureID(this.col_ID, this);
				}

				return(this.internal_Contingentement_Col_UniteMesureID_Collection);
			}
		}

		private Contingentement_Unite_Collection internal_Contingentement_Unite_Col_UniteID_Collection = null;
		public Contingentement_Unite_Collection Contingentement_Unite_Col_UniteID_Collection {

			get {

				if (this.internal_Contingentement_Unite_Col_UniteID_Collection == null) {

					this.internal_Contingentement_Unite_Col_UniteID_Collection = new Contingentement_Unite_Collection(this.connectionString);
					this.internal_Contingentement_Unite_Col_UniteID_Collection.LoadFrom_UniteID(this.col_ID, this);
				}

				return(this.internal_Contingentement_Unite_Col_UniteID_Collection);
			}
		}

		private Contrat_Transporteur_Collection internal_Contrat_Transporteur_Col_UniteID_Collection = null;
		public Contrat_Transporteur_Collection Contrat_Transporteur_Col_UniteID_Collection {

			get {

				if (this.internal_Contrat_Transporteur_Col_UniteID_Collection == null) {

					this.internal_Contrat_Transporteur_Col_UniteID_Collection = new Contrat_Transporteur_Collection(this.connectionString);
					this.internal_Contrat_Transporteur_Col_UniteID_Collection.LoadFrom_UniteID(this.col_ID, this);
				}

				return(this.internal_Contrat_Transporteur_Col_UniteID_Collection);
			}
		}

		private Essence_Unite_Collection internal_Essence_Unite_Col_UniteID_Collection = null;
		public Essence_Unite_Collection Essence_Unite_Col_UniteID_Collection {

			get {

				if (this.internal_Essence_Unite_Col_UniteID_Collection == null) {

					this.internal_Essence_Unite_Col_UniteID_Collection = new Essence_Unite_Collection(this.connectionString);
					this.internal_Essence_Unite_Col_UniteID_Collection.LoadFrom_UniteID(this.col_ID, this);
				}

				return(this.internal_Essence_Unite_Col_UniteID_Collection);
			}
		}

		private GestionVolume_Collection internal_GestionVolume_Col_UniteMesureID_Collection = null;
		public GestionVolume_Collection GestionVolume_Col_UniteMesureID_Collection {

			get {

				if (this.internal_GestionVolume_Col_UniteMesureID_Collection == null) {

					this.internal_GestionVolume_Col_UniteMesureID_Collection = new GestionVolume_Collection(this.connectionString);
					this.internal_GestionVolume_Col_UniteMesureID_Collection.LoadFrom_UniteMesureID(this.col_ID, this);
				}

				return(this.internal_GestionVolume_Col_UniteMesureID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_UniteMesureID_Collection = null;
		public Livraison_Collection Livraison_Col_UniteMesureID_Collection {

			get {

				if (this.internal_Livraison_Col_UniteMesureID_Collection == null) {

					this.internal_Livraison_Col_UniteMesureID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_UniteMesureID_Collection.LoadFrom_UniteMesureID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_UniteMesureID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_UniteMesure_Display Param = new Params.spS_UniteMesure_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_UniteMesure_Display Sp = new SPs.spS_UniteMesure_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_UniteMesure_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_UniteMesure_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.UniteMesure_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
