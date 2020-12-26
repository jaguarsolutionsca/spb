using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Indexation_EssenceUnite] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Indexation_EssenceUnite_Collection"/> class to do so.
	/// </summary>
	public sealed class Indexation_EssenceUnite_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Indexation_EssenceUnite_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Indexation_EssenceUnite_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Indexation_EssenceUnite_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Indexation_EssenceUnite_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Indexation_EssenceUnite'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Indexation_EssenceUnite", CurrentRevision, OriginalRevision));
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
		
		internal bool col_IndexationIDWasSet = false;
		private bool col_IndexationIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_IndexationID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_IndexationID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IndexationID);
			}
			set {
			
				this.col_IndexationIDWasUpdated = true;
				this.col_IndexationIDWasSet = true;
				this.col_IndexationID_Record = null;
				this.col_IndexationID = value;
			}
		}

		
		private Indexation_Record col_IndexationID_Record = null;
		public Indexation_Record Col_IndexationID_Indexation_Record {
		
			get {

				if (this.col_IndexationID_Record == null) {
				
					this.col_IndexationID_Record = new Indexation_Record(this.connectionString, this.col_IndexationID);
				}
				
				return(this.col_IndexationID_Record);
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
				this.col_ContratID_Record = null;
				this.col_ContratID = value;
			}
		}

		
		private Contrat_EssenceUnite_Record col_ContratID_Record = null;
		public Contrat_EssenceUnite_Record Col_ContratID_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_ContratID_Record == null) {
				
					this.col_ContratID_Record = new Contrat_EssenceUnite_Record(this.connectionString, this.col_ContratID, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_ContratID_Record);
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

		
		private Contrat_EssenceUnite_Record col_EssenceID_Record = null;
		public Contrat_EssenceUnite_Record Col_EssenceID_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_EssenceID_Record == null) {
				
					this.col_EssenceID_Record = new Contrat_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, this.col_EssenceID, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null);
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
				this.col_Code_Record = null;
				this.col_Code = value;
			}
		}

		
		private Contrat_EssenceUnite_Record col_Code_Record = null;
		public Contrat_EssenceUnite_Record Col_Code_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_Code_Record == null) {
				
					this.col_Code_Record = new Contrat_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, this.col_Code);
				}
				
				return(this.col_Code_Record);
			}
		}

		internal bool col_UniteIDWasSet = false;
		private bool col_UniteIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UniteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UniteID);
			}
			set {
			
				this.col_UniteIDWasUpdated = true;
				this.col_UniteIDWasSet = true;
				this.col_UniteID_Record = null;
				this.col_UniteID = value;
			}
		}

		
		private Contrat_EssenceUnite_Record col_UniteID_Record = null;
		public Contrat_EssenceUnite_Record Col_UniteID_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_UniteID_Record == null) {
				
					this.col_UniteID_Record = new Contrat_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, this.col_UniteID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_UniteID_Record);
			}
		}

		internal bool col_TauxWasSet = false;
		private bool col_TauxWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Taux = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Taux {
		
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


		public bool Refresh() {

			this.displayName = null;

			this.col_IndexationIDWasUpdated = false;
			this.col_IndexationIDWasSet = false;
			this.col_IndexationID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_CodeWasUpdated = false;
			this.col_CodeWasSet = false;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;

			this.col_UniteIDWasUpdated = false;
			this.col_UniteIDWasSet = false;
			this.col_UniteID = System.Data.SqlTypes.SqlString.Null;

			this.col_TauxWasUpdated = false;
			this.col_TauxWasSet = false;
			this.col_Taux = System.Data.SqlTypes.SqlSingle.Null;

			Params.spS_Indexation_EssenceUnite Param = new Params.spS_Indexation_EssenceUnite(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Indexation_EssenceUnite Sp = new SPs.spS_Indexation_EssenceUnite();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_IndexationID.ColumnIndex)) {

						this.col_IndexationID = sqlDataReader.GetSqlInt32(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_IndexationID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = sqlDataReader.GetSqlString(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_Code.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_UniteID.ColumnIndex)) {

						this.col_UniteID = sqlDataReader.GetSqlString(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_UniteID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_Taux.ColumnIndex)) {

						this.col_Taux = sqlDataReader.GetSqlSingle(SPs.spS_Indexation_EssenceUnite.Resultset1.Fields.Column_Taux.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_EssenceUnite_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IndexationIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TauxWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Indexation_EssenceUnite Param = new Params.spU_Indexation_EssenceUnite(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_IndexationIDWasUpdated) {

				Param.Param_IndexationID = this.col_IndexationID;
				Param.Param_ConsiderNull_IndexationID = true;
			}

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_CodeWasUpdated) {

				Param.Param_Code = this.col_Code;
				Param.Param_ConsiderNull_Code = true;
			}

			if (this.col_UniteIDWasUpdated) {

				Param.Param_UniteID = this.col_UniteID;
				Param.Param_ConsiderNull_UniteID = true;
			}

			if (this.col_TauxWasUpdated) {

				Param.Param_Taux = this.col_Taux;
				Param.Param_ConsiderNull_Taux = true;
			}

			SPs.spU_Indexation_EssenceUnite Sp = new SPs.spU_Indexation_EssenceUnite();
			if (Sp.Execute(ref Param)) {

				this.col_IndexationIDWasUpdated = false;
				this.col_ContratIDWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_CodeWasUpdated = false;
				this.col_UniteIDWasUpdated = false;
				this.col_TauxWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_EssenceUnite_Record", "Update");
			}		
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_IndexationDetailID_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_IndexationDetailID_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_IndexationDetailID_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_IndexationDetailID_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_IndexationDetailID_Collection.LoadFrom_IndexationDetailID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_IndexationDetailID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Indexation_EssenceUnite_Display Param = new Params.spS_Indexation_EssenceUnite_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Indexation_EssenceUnite_Display Sp = new SPs.spS_Indexation_EssenceUnite_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_EssenceUnite_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Indexation_EssenceUnite_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_EssenceUnite_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
