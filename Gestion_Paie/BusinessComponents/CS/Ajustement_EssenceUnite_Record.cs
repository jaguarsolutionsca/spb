using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Ajustement_EssenceUnite] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Ajustement_EssenceUnite_Collection"/> class to do so.
	/// </summary>
	public sealed class Ajustement_EssenceUnite_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Ajustement_EssenceUnite_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Ajustement_EssenceUnite_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Ajustement_EssenceUnite_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_AjustementID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_UniteID">[To be supplied.]</param>
		/// <param name="col_Code">[To be supplied.]</param>
		public Ajustement_EssenceUnite_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_AjustementID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteID, System.Data.SqlTypes.SqlString col_Code) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement_EssenceUnite'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Ajustement_EssenceUnite", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_AjustementID = col_AjustementID;
			this.col_EssenceID = col_EssenceID;
			this.col_UniteID = col_UniteID;
			this.col_Code = col_Code;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_AjustementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_AjustementID {
		
			get {
			
				return(this.col_AjustementID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_AjustementID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_EssenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceID {
		
			get {
			
				return(this.col_EssenceID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_EssenceID = value;
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
		internal System.Data.SqlTypes.SqlString col_Code = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Code {
		
			get {
			
				return(this.col_Code);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Code = value;
				}
			}
		}
		
		
		private Ajustement_Record col_AjustementID_Record = null;
		public Ajustement_Record Col_AjustementID_Ajustement_Record {
		
			get {

				if (this.col_AjustementID_Record == null) {
				
					this.col_AjustementID_Record = new Ajustement_Record(this.connectionString, this.col_AjustementID);
				}
				
				return(this.col_AjustementID_Record);
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

		
		private Contrat_EssenceUnite_Record col_UniteID_Record = null;
		public Contrat_EssenceUnite_Record Col_UniteID_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_UniteID_Record == null) {
				
					this.col_UniteID_Record = new Contrat_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, this.col_UniteID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_UniteID_Record);
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

		internal bool col_Taux_usineWasSet = false;
		private bool col_Taux_usineWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Taux_usine = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Taux_usine {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_usine);
			}
			set {
			
				this.col_Taux_usineWasUpdated = true;
				this.col_Taux_usineWasSet = true;
				this.col_Taux_usine = value;
			}
		}

		internal bool col_Taux_producteurWasSet = false;
		private bool col_Taux_producteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Taux_producteur = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Taux_producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_producteur);
			}
			set {
			
				this.col_Taux_producteurWasUpdated = true;
				this.col_Taux_producteurWasSet = true;
				this.col_Taux_producteur = value;
			}
		}

		internal bool col_Date_ModificationWasSet = false;
		private bool col_Date_ModificationWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Date_Modification = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Date_Modification {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Date_Modification);
			}
			set {
			
				this.col_Date_ModificationWasUpdated = true;
				this.col_Date_ModificationWasSet = true;
				this.col_Date_Modification = value;
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


		public bool Refresh() {

			this.displayName = null;



			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_Taux_usineWasUpdated = false;
			this.col_Taux_usineWasSet = false;
			this.col_Taux_usine = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Taux_producteurWasUpdated = false;
			this.col_Taux_producteurWasSet = false;
			this.col_Taux_producteur = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Date_ModificationWasUpdated = false;
			this.col_Date_ModificationWasSet = false;
			this.col_Date_Modification = System.Data.SqlTypes.SqlDateTime.Null;


			Params.spS_Ajustement_EssenceUnite Param = new Params.spS_Ajustement_EssenceUnite(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_AjustementID.IsNull) {

				Param.Param_AjustementID = this.col_AjustementID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_UniteID.IsNull) {

				Param.Param_UniteID = this.col_UniteID;
			}

			if (!this.col_Code.IsNull) {

				Param.Param_Code = this.col_Code;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Ajustement_EssenceUnite Sp = new SPs.spS_Ajustement_EssenceUnite();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Taux_usine.ColumnIndex)) {

						this.col_Taux_usine = sqlDataReader.GetSqlSingle(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Taux_usine.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Taux_producteur.ColumnIndex)) {

						this.col_Taux_producteur = sqlDataReader.GetSqlSingle(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Taux_producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Date_Modification.ColumnIndex)) {

						this.col_Date_Modification = sqlDataReader.GetSqlDateTime(SPs.spS_Ajustement_EssenceUnite.Resultset1.Fields.Column_Date_Modification.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Ajustement_EssenceUnite_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_usineWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_producteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Date_ModificationWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Ajustement_EssenceUnite Param = new Params.spU_Ajustement_EssenceUnite(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_AjustementID = this.col_AjustementID;
			Param.Param_EssenceID = this.col_EssenceID;
			Param.Param_UniteID = this.col_UniteID;
			Param.Param_Code = this.col_Code;

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_Taux_usineWasUpdated) {

				Param.Param_Taux_usine = this.col_Taux_usine;
				Param.Param_ConsiderNull_Taux_usine = true;
			}

			if (this.col_Taux_producteurWasUpdated) {

				Param.Param_Taux_producteur = this.col_Taux_producteur;
				Param.Param_ConsiderNull_Taux_producteur = true;
			}

			if (this.col_Date_ModificationWasUpdated) {

				Param.Param_Date_Modification = this.col_Date_Modification;
				Param.Param_ConsiderNull_Date_Modification = true;
			}

			SPs.spU_Ajustement_EssenceUnite Sp = new SPs.spU_Ajustement_EssenceUnite();
			if (Sp.Execute(ref Param)) {

				this.col_ContratIDWasUpdated = false;
				this.col_Taux_usineWasUpdated = false;
				this.col_Taux_producteurWasUpdated = false;
				this.col_Date_ModificationWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Ajustement_EssenceUnite_Record", "Update");
			}		
		}

		private AjustementCalcule_Producteur_Collection internal_AjustementCalcule_Producteur_Col_AjustementID_Collection = null;
		public AjustementCalcule_Producteur_Collection AjustementCalcule_Producteur_Col_AjustementID_Collection {

			get {

				if (this.internal_AjustementCalcule_Producteur_Col_AjustementID_Collection == null) {

					this.internal_AjustementCalcule_Producteur_Col_AjustementID_Collection = new AjustementCalcule_Producteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Producteur_Col_AjustementID_Collection.LoadFrom_AjustementID(this.col_AjustementID, this);
				}

				return(this.internal_AjustementCalcule_Producteur_Col_AjustementID_Collection);
			}
		}

		private AjustementCalcule_Producteur_Collection internal_AjustementCalcule_Producteur_Col_EssenceID_Collection = null;
		public AjustementCalcule_Producteur_Collection AjustementCalcule_Producteur_Col_EssenceID_Collection {

			get {

				if (this.internal_AjustementCalcule_Producteur_Col_EssenceID_Collection == null) {

					this.internal_AjustementCalcule_Producteur_Col_EssenceID_Collection = new AjustementCalcule_Producteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Producteur_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_EssenceID, this);
				}

				return(this.internal_AjustementCalcule_Producteur_Col_EssenceID_Collection);
			}
		}

		private AjustementCalcule_Producteur_Collection internal_AjustementCalcule_Producteur_Col_UniteID_Collection = null;
		public AjustementCalcule_Producteur_Collection AjustementCalcule_Producteur_Col_UniteID_Collection {

			get {

				if (this.internal_AjustementCalcule_Producteur_Col_UniteID_Collection == null) {

					this.internal_AjustementCalcule_Producteur_Col_UniteID_Collection = new AjustementCalcule_Producteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Producteur_Col_UniteID_Collection.LoadFrom_UniteID(this.col_UniteID, this);
				}

				return(this.internal_AjustementCalcule_Producteur_Col_UniteID_Collection);
			}
		}

		private AjustementCalcule_Producteur_Collection internal_AjustementCalcule_Producteur_Col_Code_Collection = null;
		public AjustementCalcule_Producteur_Collection AjustementCalcule_Producteur_Col_Code_Collection {

			get {

				if (this.internal_AjustementCalcule_Producteur_Col_Code_Collection == null) {

					this.internal_AjustementCalcule_Producteur_Col_Code_Collection = new AjustementCalcule_Producteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Producteur_Col_Code_Collection.LoadFrom_Code(this.col_Code, this);
				}

				return(this.internal_AjustementCalcule_Producteur_Col_Code_Collection);
			}
		}

		private AjustementCalcule_Usine_Collection internal_AjustementCalcule_Usine_Col_AjustementID_Collection = null;
		public AjustementCalcule_Usine_Collection AjustementCalcule_Usine_Col_AjustementID_Collection {

			get {

				if (this.internal_AjustementCalcule_Usine_Col_AjustementID_Collection == null) {

					this.internal_AjustementCalcule_Usine_Col_AjustementID_Collection = new AjustementCalcule_Usine_Collection(this.connectionString);
					this.internal_AjustementCalcule_Usine_Col_AjustementID_Collection.LoadFrom_AjustementID(this.col_AjustementID, this);
				}

				return(this.internal_AjustementCalcule_Usine_Col_AjustementID_Collection);
			}
		}

		private AjustementCalcule_Usine_Collection internal_AjustementCalcule_Usine_Col_EssenceID_Collection = null;
		public AjustementCalcule_Usine_Collection AjustementCalcule_Usine_Col_EssenceID_Collection {

			get {

				if (this.internal_AjustementCalcule_Usine_Col_EssenceID_Collection == null) {

					this.internal_AjustementCalcule_Usine_Col_EssenceID_Collection = new AjustementCalcule_Usine_Collection(this.connectionString);
					this.internal_AjustementCalcule_Usine_Col_EssenceID_Collection.LoadFrom_EssenceID(this.col_EssenceID, this);
				}

				return(this.internal_AjustementCalcule_Usine_Col_EssenceID_Collection);
			}
		}

		private AjustementCalcule_Usine_Collection internal_AjustementCalcule_Usine_Col_UniteID_Collection = null;
		public AjustementCalcule_Usine_Collection AjustementCalcule_Usine_Col_UniteID_Collection {

			get {

				if (this.internal_AjustementCalcule_Usine_Col_UniteID_Collection == null) {

					this.internal_AjustementCalcule_Usine_Col_UniteID_Collection = new AjustementCalcule_Usine_Collection(this.connectionString);
					this.internal_AjustementCalcule_Usine_Col_UniteID_Collection.LoadFrom_UniteID(this.col_UniteID, this);
				}

				return(this.internal_AjustementCalcule_Usine_Col_UniteID_Collection);
			}
		}

		private AjustementCalcule_Usine_Collection internal_AjustementCalcule_Usine_Col_Code_Collection = null;
		public AjustementCalcule_Usine_Collection AjustementCalcule_Usine_Col_Code_Collection {

			get {

				if (this.internal_AjustementCalcule_Usine_Col_Code_Collection == null) {

					this.internal_AjustementCalcule_Usine_Col_Code_Collection = new AjustementCalcule_Usine_Collection(this.connectionString);
					this.internal_AjustementCalcule_Usine_Col_Code_Collection.LoadFrom_Code(this.col_Code, this);
				}

				return(this.internal_AjustementCalcule_Usine_Col_Code_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Ajustement_EssenceUnite_Display Param = new Params.spS_Ajustement_EssenceUnite_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_AjustementID = this.col_AjustementID;
				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_UniteID = this.col_UniteID;
				Param.Param_Code = this.col_Code;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Ajustement_EssenceUnite_Display Sp = new SPs.spS_Ajustement_EssenceUnite_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement_EssenceUnite_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Ajustement_EssenceUnite_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Ajustement_EssenceUnite_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
