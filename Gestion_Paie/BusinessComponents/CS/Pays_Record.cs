using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Pays] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Pays_Collection"/> class to do so.
	/// </summary>
	public sealed class Pays_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Pays_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Pays_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Pays_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Pays_Record(string connectionString, System.Data.SqlTypes.SqlString col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Pays'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Pays", CurrentRevision, OriginalRevision));
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
		
		internal bool col_NomWasSet = false;
		private bool col_NomWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Nom = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Nom {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Nom);
			}
			set {
			
				this.col_NomWasUpdated = true;
				this.col_NomWasSet = true;
				this.col_Nom = value;
			}
		}

		internal bool col_CodePostal_InputMaskWasSet = false;
		private bool col_CodePostal_InputMaskWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_CodePostal_InputMask = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_CodePostal_InputMask {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_CodePostal_InputMask);
			}
			set {
			
				this.col_CodePostal_InputMaskWasUpdated = true;
				this.col_CodePostal_InputMaskWasSet = true;
				this.col_CodePostal_InputMask = value;
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

			this.col_NomWasUpdated = false;
			this.col_NomWasSet = false;
			this.col_Nom = System.Data.SqlTypes.SqlString.Null;

			this.col_CodePostal_InputMaskWasUpdated = false;
			this.col_CodePostal_InputMaskWasSet = false;
			this.col_CodePostal_InputMask = System.Data.SqlTypes.SqlString.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Pays Param = new Params.spS_Pays(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Pays Sp = new SPs.spS_Pays();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Pays.Resultset1.Fields.Column_Nom.ColumnIndex)) {

						this.col_Nom = sqlDataReader.GetSqlString(SPs.spS_Pays.Resultset1.Fields.Column_Nom.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Pays.Resultset1.Fields.Column_CodePostal_InputMask.ColumnIndex)) {

						this.col_CodePostal_InputMask = sqlDataReader.GetSqlString(SPs.spS_Pays.Resultset1.Fields.Column_CodePostal_InputMask.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Pays.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Pays.Resultset1.Fields.Column_Actif.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Pays_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NomWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodePostal_InputMaskWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Pays Param = new Params.spU_Pays(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_NomWasUpdated) {

				Param.Param_Nom = this.col_Nom;
				Param.Param_ConsiderNull_Nom = true;
			}

			if (this.col_CodePostal_InputMaskWasUpdated) {

				Param.Param_CodePostal_InputMask = this.col_CodePostal_InputMask;
				Param.Param_ConsiderNull_CodePostal_InputMask = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			SPs.spU_Pays Sp = new SPs.spU_Pays();
			if (Sp.Execute(ref Param)) {

				this.col_NomWasUpdated = false;
				this.col_CodePostal_InputMaskWasUpdated = false;
				this.col_ActifWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Pays_Record", "Update");
			}		
		}

		private Fournisseur_Collection internal_Fournisseur_Col_PaysID_Collection = null;
		public Fournisseur_Collection Fournisseur_Col_PaysID_Collection {

			get {

				if (this.internal_Fournisseur_Col_PaysID_Collection == null) {

					this.internal_Fournisseur_Col_PaysID_Collection = new Fournisseur_Collection(this.connectionString);
					this.internal_Fournisseur_Col_PaysID_Collection.LoadFrom_PaysID(this.col_ID, this);
				}

				return(this.internal_Fournisseur_Col_PaysID_Collection);
			}
		}

		private Usine_Collection internal_Usine_Col_PaysID_Collection = null;
		public Usine_Collection Usine_Col_PaysID_Collection {

			get {

				if (this.internal_Usine_Col_PaysID_Collection == null) {

					this.internal_Usine_Col_PaysID_Collection = new Usine_Collection(this.connectionString);
					this.internal_Usine_Col_PaysID_Collection.LoadFrom_PaysID(this.col_ID, this);
				}

				return(this.internal_Usine_Col_PaysID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Pays_Display Param = new Params.spS_Pays_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Pays_Display Sp = new SPs.spS_Pays_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Pays_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Pays_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Pays_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
