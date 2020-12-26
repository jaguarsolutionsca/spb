using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Lot_SuperficieBoisee] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Lot_SuperficieBoisee_Collection"/> class to do so.
	/// </summary>
	public sealed class Lot_SuperficieBoisee_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Lot_SuperficieBoisee_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Lot_SuperficieBoisee_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Lot_SuperficieBoisee_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_Annee">[To be supplied.]</param>
		/// <param name="col_LotID">[To be supplied.]</param>
		public Lot_SuperficieBoisee_Record(string connectionString, System.Data.SqlTypes.SqlDateTime col_Annee, System.Data.SqlTypes.SqlInt32 col_LotID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Lot_SuperficieBoisee'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Lot_SuperficieBoisee", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_Annee = col_Annee;
			this.col_LotID = col_LotID;
		}
		
		internal System.Data.SqlTypes.SqlDateTime col_Annee = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Annee {
		
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
		
		internal bool col_Superficie_boiseeWasSet = false;
		private bool col_Superficie_boiseeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Superficie_boisee = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Superficie_boisee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Superficie_boisee);
			}
			set {
			
				this.col_Superficie_boiseeWasUpdated = true;
				this.col_Superficie_boiseeWasSet = true;
				this.col_Superficie_boisee = value;
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


		public bool Refresh() {

			this.displayName = null;

			this.col_Superficie_boiseeWasUpdated = false;
			this.col_Superficie_boiseeWasSet = false;
			this.col_Superficie_boisee = System.Data.SqlTypes.SqlSingle.Null;


			Params.spS_Lot_SuperficieBoisee Param = new Params.spS_Lot_SuperficieBoisee(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_Annee.IsNull) {

				Param.Param_Annee = this.col_Annee;
			}

			if (!this.col_LotID.IsNull) {

				Param.Param_LotID = this.col_LotID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Lot_SuperficieBoisee Sp = new SPs.spS_Lot_SuperficieBoisee();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Lot_SuperficieBoisee.Resultset1.Fields.Column_Superficie_boisee.ColumnIndex)) {

						this.col_Superficie_boisee = sqlDataReader.GetSqlSingle(SPs.spS_Lot_SuperficieBoisee.Resultset1.Fields.Column_Superficie_boisee.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_SuperficieBoisee_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Superficie_boiseeWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Lot_SuperficieBoisee Param = new Params.spU_Lot_SuperficieBoisee(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_Annee = this.col_Annee;
			Param.Param_LotID = this.col_LotID;

			if (this.col_Superficie_boiseeWasUpdated) {

				Param.Param_Superficie_boisee = this.col_Superficie_boisee;
				Param.Param_ConsiderNull_Superficie_boisee = true;
			}

			SPs.spU_Lot_SuperficieBoisee Sp = new SPs.spU_Lot_SuperficieBoisee();
			if (Sp.Execute(ref Param)) {

				this.col_Superficie_boiseeWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_SuperficieBoisee_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Lot_SuperficieBoisee_Display Param = new Params.spS_Lot_SuperficieBoisee_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_Annee = this.col_Annee;
				Param.Param_LotID = this.col_LotID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Lot_SuperficieBoisee_Display Sp = new SPs.spS_Lot_SuperficieBoisee_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Lot_SuperficieBoisee_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Lot_SuperficieBoisee_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_SuperficieBoisee_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
