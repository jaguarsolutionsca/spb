using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Indexation_Municipalite] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Indexation_Municipalite_Collection"/> class to do so.
	/// </summary>
	public sealed class Indexation_Municipalite_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Indexation_Municipalite_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Indexation_Municipalite_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Indexation_Municipalite_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Indexation_Municipalite_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Indexation_Municipalite'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Indexation_Municipalite", CurrentRevision, OriginalRevision));
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

		internal bool col_MontantWasSet = false;
		private bool col_MontantWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Montant = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Montant {
		
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


		public bool Refresh() {

			this.displayName = null;

			this.col_IndexationIDWasUpdated = false;
			this.col_IndexationIDWasSet = false;
			this.col_IndexationID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_MunicipaliteIDWasUpdated = false;
			this.col_MunicipaliteIDWasSet = false;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;

			this.col_MontantWasUpdated = false;
			this.col_MontantWasSet = false;
			this.col_Montant = System.Data.SqlTypes.SqlSingle.Null;

			this.col_ZoneIDWasUpdated = false;
			this.col_ZoneIDWasSet = false;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;

			Params.spS_Indexation_Municipalite Param = new Params.spS_Indexation_Municipalite(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Indexation_Municipalite Sp = new SPs.spS_Indexation_Municipalite();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_Municipalite.Resultset1.Fields.Column_IndexationID.ColumnIndex)) {

						this.col_IndexationID = sqlDataReader.GetSqlInt32(SPs.spS_Indexation_Municipalite.Resultset1.Fields.Column_IndexationID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_Municipalite.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex)) {

						this.col_MunicipaliteID = sqlDataReader.GetSqlString(SPs.spS_Indexation_Municipalite.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_Municipalite.Resultset1.Fields.Column_Montant.ColumnIndex)) {

						this.col_Montant = sqlDataReader.GetSqlSingle(SPs.spS_Indexation_Municipalite.Resultset1.Fields.Column_Montant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_Municipalite.Resultset1.Fields.Column_ZoneID.ColumnIndex)) {

						this.col_ZoneID = sqlDataReader.GetSqlString(SPs.spS_Indexation_Municipalite.Resultset1.Fields.Column_ZoneID.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_Municipalite_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IndexationIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MunicipaliteIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MontantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ZoneIDWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Indexation_Municipalite Param = new Params.spU_Indexation_Municipalite(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_IndexationIDWasUpdated) {

				Param.Param_IndexationID = this.col_IndexationID;
				Param.Param_ConsiderNull_IndexationID = true;
			}

			if (this.col_MunicipaliteIDWasUpdated) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
				Param.Param_ConsiderNull_MunicipaliteID = true;
			}

			if (this.col_MontantWasUpdated) {

				Param.Param_Montant = this.col_Montant;
				Param.Param_ConsiderNull_Montant = true;
			}

			if (this.col_ZoneIDWasUpdated) {

				Param.Param_ZoneID = this.col_ZoneID;
				Param.Param_ConsiderNull_ZoneID = true;
			}

			SPs.spU_Indexation_Municipalite Sp = new SPs.spU_Indexation_Municipalite();
			if (Sp.Execute(ref Param)) {

				this.col_IndexationIDWasUpdated = false;
				this.col_MunicipaliteIDWasUpdated = false;
				this.col_MontantWasUpdated = false;
				this.col_ZoneIDWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_Municipalite_Record", "Update");
			}		
		}

		private IndexationCalcule_Transporteur_Collection internal_IndexationCalcule_Transporteur_Col_IndexationDetailID_Collection = null;
		public IndexationCalcule_Transporteur_Collection IndexationCalcule_Transporteur_Col_IndexationDetailID_Collection {

			get {

				if (this.internal_IndexationCalcule_Transporteur_Col_IndexationDetailID_Collection == null) {

					this.internal_IndexationCalcule_Transporteur_Col_IndexationDetailID_Collection = new IndexationCalcule_Transporteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Transporteur_Col_IndexationDetailID_Collection.LoadFrom_IndexationDetailID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Transporteur_Col_IndexationDetailID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Indexation_Municipalite_Display Param = new Params.spS_Indexation_Municipalite_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Indexation_Municipalite_Display Sp = new SPs.spS_Indexation_Municipalite_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_Municipalite_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Indexation_Municipalite_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_Municipalite_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
