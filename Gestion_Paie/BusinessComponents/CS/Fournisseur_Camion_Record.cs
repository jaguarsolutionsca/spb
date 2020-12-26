using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Fournisseur_Camion] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Fournisseur_Camion_Collection"/> class to do so.
	/// </summary>
	public sealed class Fournisseur_Camion_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Fournisseur_Camion_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Fournisseur_Camion_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Fournisseur_Camion_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_FournisseurID">[To be supplied.]</param>
		/// <param name="col_VR">[To be supplied.]</param>
		public Fournisseur_Camion_Record(string connectionString, System.Data.SqlTypes.SqlString col_FournisseurID, System.Data.SqlTypes.SqlString col_VR) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur_Camion'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Fournisseur_Camion", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_FournisseurID = col_FournisseurID;
			this.col_VR = col_VR;
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
		internal System.Data.SqlTypes.SqlString col_VR = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_VR {
		
			get {
			
				return(this.col_VR);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_VR = value;
				}
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

		internal bool col_MasseLimiteWasSet = false;
		private bool col_MasseLimiteWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_MasseLimite = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_MasseLimite {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MasseLimite);
			}
			set {
			
				this.col_MasseLimiteWasUpdated = true;
				this.col_MasseLimiteWasSet = true;
				this.col_MasseLimite = value;
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


			this.col_MasseLimiteWasUpdated = false;
			this.col_MasseLimiteWasSet = false;
			this.col_MasseLimite = System.Data.SqlTypes.SqlDouble.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Fournisseur_Camion Param = new Params.spS_Fournisseur_Camion(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_FournisseurID.IsNull) {

				Param.Param_FournisseurID = this.col_FournisseurID;
			}

			if (!this.col_VR.IsNull) {

				Param.Param_VR = this.col_VR;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Fournisseur_Camion Sp = new SPs.spS_Fournisseur_Camion();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur_Camion.Resultset1.Fields.Column_MasseLimite.ColumnIndex)) {

						this.col_MasseLimite = sqlDataReader.GetSqlDouble(SPs.spS_Fournisseur_Camion.Resultset1.Fields.Column_MasseLimite.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur_Camion.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur_Camion.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Camion_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MasseLimiteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Fournisseur_Camion Param = new Params.spU_Fournisseur_Camion(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_FournisseurID = this.col_FournisseurID;
			Param.Param_VR = this.col_VR;

			if (this.col_MasseLimiteWasUpdated) {

				Param.Param_MasseLimite = this.col_MasseLimite;
				Param.Param_ConsiderNull_MasseLimite = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			SPs.spU_Fournisseur_Camion Sp = new SPs.spU_Fournisseur_Camion();
			if (Sp.Execute(ref Param)) {

				this.col_MasseLimiteWasUpdated = false;
				this.col_ActifWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Camion_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Fournisseur_Camion_Display Param = new Params.spS_Fournisseur_Camion_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_FournisseurID = this.col_FournisseurID;
				Param.Param_VR = this.col_VR;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Fournisseur_Camion_Display Sp = new SPs.spS_Fournisseur_Camion_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur_Camion_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Fournisseur_Camion_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Camion_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
