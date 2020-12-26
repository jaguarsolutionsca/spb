using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Contingentement_Unite] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Contingentement_Unite_Collection"/> class to do so.
	/// </summary>
	public sealed class Contingentement_Unite_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Contingentement_Unite_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Contingentement_Unite_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Contingentement_Unite_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ContingentementID">[To be supplied.]</param>
		/// <param name="col_UniteID">[To be supplied.]</param>
		public Contingentement_Unite_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ContingentementID, System.Data.SqlTypes.SqlString col_UniteID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_Unite'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement_Unite", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ContingentementID = col_ContingentementID;
			this.col_UniteID = col_UniteID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ContingentementID {
		
			get {
			
				return(this.col_ContingentementID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ContingentementID = value;
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
		
		
		private Contingentement_Record col_ContingentementID_Record = null;
		public Contingentement_Record Col_ContingentementID_Contingentement_Record {
		
			get {

				if (this.col_ContingentementID_Record == null) {
				
					this.col_ContingentementID_Record = new Contingentement_Record(this.connectionString, this.col_ContingentementID);
				}
				
				return(this.col_ContingentementID_Record);
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

		internal bool col_FacteurWasSet = false;
		private bool col_FacteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Facteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Facteur {
		
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


		public bool Refresh() {

			this.displayName = null;


			this.col_FacteurWasUpdated = false;
			this.col_FacteurWasSet = false;
			this.col_Facteur = System.Data.SqlTypes.SqlDouble.Null;

			Params.spS_Contingentement_Unite Param = new Params.spS_Contingentement_Unite(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ContingentementID.IsNull) {

				Param.Param_ContingentementID = this.col_ContingentementID;
			}

			if (!this.col_UniteID.IsNull) {

				Param.Param_UniteID = this.col_UniteID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contingentement_Unite Sp = new SPs.spS_Contingentement_Unite();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Unite.Resultset1.Fields.Column_Facteur.ColumnIndex)) {

						this.col_Facteur = sqlDataReader.GetSqlDouble(SPs.spS_Contingentement_Unite.Resultset1.Fields.Column_Facteur.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Unite_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FacteurWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Contingentement_Unite Param = new Params.spU_Contingentement_Unite(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ContingentementID = this.col_ContingentementID;
			Param.Param_UniteID = this.col_UniteID;

			if (this.col_FacteurWasUpdated) {

				Param.Param_Facteur = this.col_Facteur;
				Param.Param_ConsiderNull_Facteur = true;
			}

			SPs.spU_Contingentement_Unite Sp = new SPs.spU_Contingentement_Unite();
			if (Sp.Execute(ref Param)) {

				this.col_FacteurWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Unite_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Contingentement_Unite_Display Param = new Params.spS_Contingentement_Unite_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ContingentementID = this.col_ContingentementID;
				Param.Param_UniteID = this.col_UniteID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Contingentement_Unite_Display Sp = new SPs.spS_Contingentement_Unite_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Unite_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Contingentement_Unite_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Unite_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
