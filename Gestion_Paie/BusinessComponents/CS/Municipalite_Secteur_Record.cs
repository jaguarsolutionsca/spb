using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Municipalite_Secteur] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Municipalite_Secteur_Collection"/> class to do so.
	/// </summary>
	public sealed class Municipalite_Secteur_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Municipalite_Secteur_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Municipalite_Secteur_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Municipalite_Secteur_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		/// <param name="col_Secteur">[To be supplied.]</param>
		public Municipalite_Secteur_Record(string connectionString, System.Data.SqlTypes.SqlString col_MunicipaliteID, System.Data.SqlTypes.SqlString col_Secteur) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Municipalite_Secteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Municipalite_Secteur", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_MunicipaliteID = col_MunicipaliteID;
			this.col_Secteur = col_Secteur;
		}
		
		internal System.Data.SqlTypes.SqlString col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {
		
			get {
			
				return(this.col_MunicipaliteID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_MunicipaliteID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_Secteur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Secteur {
		
			get {
			
				return(this.col_Secteur);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Secteur = value;
				}
			}
		}
		
		
		private Municipalite_Record col_MunicipaliteID_Record = null;
		public Municipalite_Record Col_MunicipaliteID_Municipalite_Record {
		
			get {

				if (this.col_MunicipaliteID_Record == null) {
				
					this.col_MunicipaliteID_Record = new Municipalite_Record(this.connectionString, this.col_MunicipaliteID);
				}
				
				return(this.col_MunicipaliteID_Record);
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


			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Municipalite_Secteur Param = new Params.spS_Municipalite_Secteur(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}

			if (!this.col_Secteur.IsNull) {

				Param.Param_Secteur = this.col_Secteur;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Municipalite_Secteur Sp = new SPs.spS_Municipalite_Secteur();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite_Secteur.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Municipalite_Secteur.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Secteur_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Municipalite_Secteur Param = new Params.spU_Municipalite_Secteur(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			Param.Param_Secteur = this.col_Secteur;

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			SPs.spU_Municipalite_Secteur Sp = new SPs.spU_Municipalite_Secteur();
			if (Sp.Execute(ref Param)) {

				this.col_ActifWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Secteur_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Municipalite_Secteur_Display Param = new Params.spS_Municipalite_Secteur_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
				Param.Param_Secteur = this.col_Secteur;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Municipalite_Secteur_Display Sp = new SPs.spS_Municipalite_Secteur_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Municipalite_Secteur_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Municipalite_Secteur_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Secteur_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
