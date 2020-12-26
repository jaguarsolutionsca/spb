using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [LotContingente] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.LotContingente_Collection"/> class to do so.
	/// </summary>
	public sealed class LotContingente_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the LotContingente_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.LotContingente_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public LotContingente_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_LotID">[To be supplied.]</param>
		/// <param name="col_Annee">[To be supplied.]</param>
		/// <param name="col_FournisseurID">[To be supplied.]</param>
		public LotContingente_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_LotID, System.Data.SqlTypes.SqlInt32 col_Annee, System.Data.SqlTypes.SqlString col_FournisseurID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'LotContingente'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "LotContingente", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_LotID = col_LotID;
			this.col_Annee = col_Annee;
			this.col_FournisseurID = col_FournisseurID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_LotID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LotID {
		
			get {
			
				return(this.col_LotID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_LotID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {
		
			get {
			
				return(this.col_Annee);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Annee = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_FournisseurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_FournisseurID {
		
			get {
			
				return(this.col_FournisseurID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_FournisseurID = value;
				}
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

		internal bool col_SuperficieContingenteeWasSet = false;
		private bool col_SuperficieContingenteeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_SuperficieContingentee = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_SuperficieContingentee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_SuperficieContingentee);
			}
			set {
			
				this.col_SuperficieContingenteeWasUpdated = true;
				this.col_SuperficieContingenteeWasSet = true;
				this.col_SuperficieContingentee = value;
			}
		}

		internal bool col_OverrideWasSet = false;
		private bool col_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Override);
			}
			set {
			
				this.col_OverrideWasUpdated = true;
				this.col_OverrideWasSet = true;
				this.col_Override = value;
			}
		}

		
		private Fournisseur_Record col_FournisseurID_Record = null;
		public Fournisseur_Record Col_FournisseurID_Fournisseur_Record {
		
			get {

				if (this.col_FournisseurID_Record == null) {
				
					this.col_FournisseurID_Record = new Fournisseur_Record(this.connectionString, this.col_FournisseurID);
				}
				
				return(this.col_FournisseurID_Record);
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_SuperficieContingenteeWasUpdated = false;
			this.col_SuperficieContingenteeWasSet = false;
			this.col_SuperficieContingentee = System.Data.SqlTypes.SqlSingle.Null;

			this.col_OverrideWasUpdated = false;
			this.col_OverrideWasSet = false;
			this.col_Override = System.Data.SqlTypes.SqlBoolean.Null;


			Params.spS_LotContingente Param = new Params.spS_LotContingente(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_LotID.IsNull) {

				Param.Param_LotID = this.col_LotID;
			}

			if (!this.col_Annee.IsNull) {

				Param.Param_Annee = this.col_Annee;
			}

			if (!this.col_FournisseurID.IsNull) {

				Param.Param_FournisseurID = this.col_FournisseurID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_LotContingente Sp = new SPs.spS_LotContingente();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_LotContingente.Resultset1.Fields.Column_SuperficieContingentee.ColumnIndex)) {

						this.col_SuperficieContingentee = sqlDataReader.GetSqlSingle(SPs.spS_LotContingente.Resultset1.Fields.Column_SuperficieContingentee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_LotContingente.Resultset1.Fields.Column_Override.ColumnIndex)) {

						this.col_Override = sqlDataReader.GetSqlBoolean(SPs.spS_LotContingente.Resultset1.Fields.Column_Override.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.LotContingente_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_SuperficieContingenteeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_OverrideWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_LotContingente Param = new Params.spU_LotContingente(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_LotID = this.col_LotID;
			Param.Param_Annee = this.col_Annee;
			Param.Param_FournisseurID = this.col_FournisseurID;

			if (this.col_SuperficieContingenteeWasUpdated) {

				Param.Param_SuperficieContingentee = this.col_SuperficieContingentee;
				Param.Param_ConsiderNull_SuperficieContingentee = true;
			}

			if (this.col_OverrideWasUpdated) {

				Param.Param_Override = this.col_Override;
				Param.Param_ConsiderNull_Override = true;
			}

			SPs.spU_LotContingente Sp = new SPs.spU_LotContingente();
			if (Sp.Execute(ref Param)) {

				this.col_SuperficieContingenteeWasUpdated = false;
				this.col_OverrideWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.LotContingente_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_LotContingente_Display Param = new Params.spS_LotContingente_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_LotID = this.col_LotID;
				Param.Param_Annee = this.col_Annee;
				Param.Param_FournisseurID = this.col_FournisseurID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_LotContingente_Display Sp = new SPs.spS_LotContingente_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_LotContingente_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_LotContingente_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.LotContingente_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
