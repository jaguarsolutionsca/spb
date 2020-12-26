using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Livraison_Permis] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Livraison_Permis_Collection"/> class to do so.
	/// </summary>
	public sealed class Livraison_Permis_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Livraison_Permis_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Livraison_Permis_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Livraison_Permis_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_LivraisonID">[To be supplied.]</param>
		/// <param name="col_PermisID">[To be supplied.]</param>
		public Livraison_Permis_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_LivraisonID, System.Data.SqlTypes.SqlInt32 col_PermisID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison_Permis'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Livraison_Permis", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_LivraisonID = col_LivraisonID;
			this.col_PermisID = col_PermisID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonID {
		
			get {
			
				return(this.col_LivraisonID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_LivraisonID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlInt32 col_PermisID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_PermisID {
		
			get {
			
				return(this.col_PermisID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_PermisID = value;
				}
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

		
		private Permit_Record col_PermisID_Record = null;
		public Permit_Record Col_PermisID_Permit_Record {
		
			get {

				if (this.col_PermisID_Record == null) {
				
					this.col_PermisID_Record = new Permit_Record(this.connectionString, this.col_PermisID);
				}
				
				return(this.col_PermisID_Record);
			}
		}

		internal bool col_NumeroFactureUsineWasSet = false;
		private bool col_NumeroFactureUsineWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NumeroFactureUsine {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NumeroFactureUsine);
			}
			set {
			
				this.col_NumeroFactureUsineWasUpdated = true;
				this.col_NumeroFactureUsineWasSet = true;
				this.col_NumeroFactureUsine = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_NumeroFactureUsineWasUpdated = false;
			this.col_NumeroFactureUsineWasSet = false;
			this.col_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;

			Params.spS_Livraison_Permis Param = new Params.spS_Livraison_Permis(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_LivraisonID.IsNull) {

				Param.Param_LivraisonID = this.col_LivraisonID;
			}

			if (!this.col_PermisID.IsNull) {

				Param.Param_PermisID = this.col_PermisID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Livraison_Permis Sp = new SPs.spS_Livraison_Permis();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Permis.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex)) {

						this.col_NumeroFactureUsine = sqlDataReader.GetSqlString(SPs.spS_Livraison_Permis.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Permis_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NumeroFactureUsineWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Livraison_Permis Param = new Params.spU_Livraison_Permis(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_LivraisonID = this.col_LivraisonID;
			Param.Param_PermisID = this.col_PermisID;

			if (this.col_NumeroFactureUsineWasUpdated) {

				Param.Param_NumeroFactureUsine = this.col_NumeroFactureUsine;
				Param.Param_ConsiderNull_NumeroFactureUsine = true;
			}

			SPs.spU_Livraison_Permis Sp = new SPs.spU_Livraison_Permis();
			if (Sp.Execute(ref Param)) {

				this.col_NumeroFactureUsineWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Permis_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Livraison_Permis_Display Param = new Params.spS_Livraison_Permis_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_LivraisonID = this.col_LivraisonID;
				Param.Param_PermisID = this.col_PermisID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Livraison_Permis_Display Sp = new SPs.spS_Livraison_Permis_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Permis_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Livraison_Permis_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Permis_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
