using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Indexation] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Indexation_Collection"/> class to do so.
	/// </summary>
	public sealed class Indexation_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Indexation_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Indexation_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Indexation_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Indexation_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Indexation'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Indexation", CurrentRevision, OriginalRevision));
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
		
		internal bool col_DateIndexationWasSet = false;
		private bool col_DateIndexationWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateIndexation = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateIndexation {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateIndexation);
			}
			set {
			
				this.col_DateIndexationWasUpdated = true;
				this.col_DateIndexationWasSet = true;
				this.col_DateIndexation = value;
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

		
		private Contrat_Record col_ContratID_Record = null;
		public Contrat_Record Col_ContratID_Contrat_Record {
		
			get {

				if (this.col_ContratID_Record == null) {
				
					this.col_ContratID_Record = new Contrat_Record(this.connectionString, this.col_ContratID);
				}
				
				return(this.col_ContratID_Record);
			}
		}

		internal bool col_Periode_DebutWasSet = false;
		private bool col_Periode_DebutWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Periode_Debut = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Periode_Debut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Periode_Debut);
			}
			set {
			
				this.col_Periode_DebutWasUpdated = true;
				this.col_Periode_DebutWasSet = true;
				this.col_Periode_Debut = value;
			}
		}

		internal bool col_Periode_FinWasSet = false;
		private bool col_Periode_FinWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Periode_Fin = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Periode_Fin {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Periode_Fin);
			}
			set {
			
				this.col_Periode_FinWasUpdated = true;
				this.col_Periode_FinWasSet = true;
				this.col_Periode_Fin = value;
			}
		}

		internal bool col_TypeIndexationWasSet = false;
		private bool col_TypeIndexationWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TypeIndexation = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TypeIndexation {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TypeIndexation);
			}
			set {
			
				this.col_TypeIndexationWasUpdated = true;
				this.col_TypeIndexationWasSet = true;
				this.col_TypeIndexation_Record = null;
				this.col_TypeIndexation = value;
			}
		}

		
		private TypeIndexation_Record col_TypeIndexation_Record = null;
		public TypeIndexation_Record Col_TypeIndexation_TypeIndexation_Record {
		
			get {

				if (this.col_TypeIndexation_Record == null) {
				
					this.col_TypeIndexation_Record = new TypeIndexation_Record(this.connectionString, this.col_TypeIndexation);
				}
				
				return(this.col_TypeIndexation_Record);
			}
		}

		internal bool col_PourcentageDuMontantWasSet = false;
		private bool col_PourcentageDuMontantWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_PourcentageDuMontant = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_PourcentageDuMontant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PourcentageDuMontant);
			}
			set {
			
				this.col_PourcentageDuMontantWasUpdated = true;
				this.col_PourcentageDuMontantWasSet = true;
				this.col_PourcentageDuMontant = value;
			}
		}

		internal bool col_FactureWasSet = false;
		private bool col_FactureWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Facture = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Facture {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Facture);
			}
			set {
			
				this.col_FactureWasUpdated = true;
				this.col_FactureWasSet = true;
				this.col_Facture = value;
			}
		}

		internal bool col_IndexationTransporteurWasSet = false;
		private bool col_IndexationTransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_IndexationTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_IndexationTransporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IndexationTransporteur);
			}
			set {
			
				this.col_IndexationTransporteurWasUpdated = true;
				this.col_IndexationTransporteurWasSet = true;
				this.col_IndexationTransporteur = value;
			}
		}

		internal bool col_Date_DebutWasSet = false;
		private bool col_Date_DebutWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Date_Debut = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Date_Debut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Date_Debut);
			}
			set {
			
				this.col_Date_DebutWasUpdated = true;
				this.col_Date_DebutWasSet = true;
				this.col_Date_Debut = value;
			}
		}

		internal bool col_Date_FinWasSet = false;
		private bool col_Date_FinWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Date_Fin = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Date_Fin {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Date_Fin);
			}
			set {
			
				this.col_Date_FinWasUpdated = true;
				this.col_Date_FinWasSet = true;
				this.col_Date_Fin = value;
			}
		}

		internal bool col_IndexationManuelleWasSet = false;
		private bool col_IndexationManuelleWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_IndexationManuelle = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_IndexationManuelle {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IndexationManuelle);
			}
			set {
			
				this.col_IndexationManuelleWasUpdated = true;
				this.col_IndexationManuelleWasSet = true;
				this.col_IndexationManuelle = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_DateIndexationWasUpdated = false;
			this.col_DateIndexationWasSet = false;
			this.col_DateIndexation = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_Periode_DebutWasUpdated = false;
			this.col_Periode_DebutWasSet = false;
			this.col_Periode_Debut = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Periode_FinWasUpdated = false;
			this.col_Periode_FinWasSet = false;
			this.col_Periode_Fin = System.Data.SqlTypes.SqlInt32.Null;

			this.col_TypeIndexationWasUpdated = false;
			this.col_TypeIndexationWasSet = false;
			this.col_TypeIndexation = System.Data.SqlTypes.SqlString.Null;

			this.col_PourcentageDuMontantWasUpdated = false;
			this.col_PourcentageDuMontantWasSet = false;
			this.col_PourcentageDuMontant = System.Data.SqlTypes.SqlSingle.Null;

			this.col_FactureWasUpdated = false;
			this.col_FactureWasSet = false;
			this.col_Facture = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_IndexationTransporteurWasUpdated = false;
			this.col_IndexationTransporteurWasSet = false;
			this.col_IndexationTransporteur = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Date_DebutWasUpdated = false;
			this.col_Date_DebutWasSet = false;
			this.col_Date_Debut = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_Date_FinWasUpdated = false;
			this.col_Date_FinWasSet = false;
			this.col_Date_Fin = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_IndexationManuelleWasUpdated = false;
			this.col_IndexationManuelleWasSet = false;
			this.col_IndexationManuelle = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Indexation Param = new Params.spS_Indexation(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Indexation Sp = new SPs.spS_Indexation();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_DateIndexation.ColumnIndex)) {

						this.col_DateIndexation = sqlDataReader.GetSqlDateTime(SPs.spS_Indexation.Resultset1.Fields.Column_DateIndexation.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_Indexation.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Periode_Debut.ColumnIndex)) {

						this.col_Periode_Debut = sqlDataReader.GetSqlInt32(SPs.spS_Indexation.Resultset1.Fields.Column_Periode_Debut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Periode_Fin.ColumnIndex)) {

						this.col_Periode_Fin = sqlDataReader.GetSqlInt32(SPs.spS_Indexation.Resultset1.Fields.Column_Periode_Fin.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_TypeIndexation.ColumnIndex)) {

						this.col_TypeIndexation = sqlDataReader.GetSqlString(SPs.spS_Indexation.Resultset1.Fields.Column_TypeIndexation.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_PourcentageDuMontant.ColumnIndex)) {

						this.col_PourcentageDuMontant = sqlDataReader.GetSqlSingle(SPs.spS_Indexation.Resultset1.Fields.Column_PourcentageDuMontant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Facture.ColumnIndex)) {

						this.col_Facture = sqlDataReader.GetSqlBoolean(SPs.spS_Indexation.Resultset1.Fields.Column_Facture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_IndexationTransporteur.ColumnIndex)) {

						this.col_IndexationTransporteur = sqlDataReader.GetSqlBoolean(SPs.spS_Indexation.Resultset1.Fields.Column_IndexationTransporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Date_Debut.ColumnIndex)) {

						this.col_Date_Debut = sqlDataReader.GetSqlDateTime(SPs.spS_Indexation.Resultset1.Fields.Column_Date_Debut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_Date_Fin.ColumnIndex)) {

						this.col_Date_Fin = sqlDataReader.GetSqlDateTime(SPs.spS_Indexation.Resultset1.Fields.Column_Date_Fin.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Indexation.Resultset1.Fields.Column_IndexationManuelle.ColumnIndex)) {

						this.col_IndexationManuelle = sqlDataReader.GetSqlBoolean(SPs.spS_Indexation.Resultset1.Fields.Column_IndexationManuelle.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateIndexationWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Periode_DebutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Periode_FinWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TypeIndexationWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PourcentageDuMontantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IndexationTransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Date_DebutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Date_FinWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IndexationManuelleWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Indexation Param = new Params.spU_Indexation(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DateIndexationWasUpdated) {

				Param.Param_DateIndexation = this.col_DateIndexation;
				Param.Param_ConsiderNull_DateIndexation = true;
			}

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_Periode_DebutWasUpdated) {

				Param.Param_Periode_Debut = this.col_Periode_Debut;
				Param.Param_ConsiderNull_Periode_Debut = true;
			}

			if (this.col_Periode_FinWasUpdated) {

				Param.Param_Periode_Fin = this.col_Periode_Fin;
				Param.Param_ConsiderNull_Periode_Fin = true;
			}

			if (this.col_TypeIndexationWasUpdated) {

				Param.Param_TypeIndexation = this.col_TypeIndexation;
				Param.Param_ConsiderNull_TypeIndexation = true;
			}

			if (this.col_PourcentageDuMontantWasUpdated) {

				Param.Param_PourcentageDuMontant = this.col_PourcentageDuMontant;
				Param.Param_ConsiderNull_PourcentageDuMontant = true;
			}

			if (this.col_FactureWasUpdated) {

				Param.Param_Facture = this.col_Facture;
				Param.Param_ConsiderNull_Facture = true;
			}

			if (this.col_IndexationTransporteurWasUpdated) {

				Param.Param_IndexationTransporteur = this.col_IndexationTransporteur;
				Param.Param_ConsiderNull_IndexationTransporteur = true;
			}

			if (this.col_Date_DebutWasUpdated) {

				Param.Param_Date_Debut = this.col_Date_Debut;
				Param.Param_ConsiderNull_Date_Debut = true;
			}

			if (this.col_Date_FinWasUpdated) {

				Param.Param_Date_Fin = this.col_Date_Fin;
				Param.Param_ConsiderNull_Date_Fin = true;
			}

			if (this.col_IndexationManuelleWasUpdated) {

				Param.Param_IndexationManuelle = this.col_IndexationManuelle;
				Param.Param_ConsiderNull_IndexationManuelle = true;
			}

			SPs.spU_Indexation Sp = new SPs.spU_Indexation();
			if (Sp.Execute(ref Param)) {

				this.col_DateIndexationWasUpdated = false;
				this.col_ContratIDWasUpdated = false;
				this.col_Periode_DebutWasUpdated = false;
				this.col_Periode_FinWasUpdated = false;
				this.col_TypeIndexationWasUpdated = false;
				this.col_PourcentageDuMontantWasUpdated = false;
				this.col_FactureWasUpdated = false;
				this.col_IndexationTransporteurWasUpdated = false;
				this.col_Date_DebutWasUpdated = false;
				this.col_Date_FinWasUpdated = false;
				this.col_IndexationManuelleWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_Record", "Update");
			}		
		}

		private Indexation_EssenceUnite_Collection internal_Indexation_EssenceUnite_Col_IndexationID_Collection = null;
		public Indexation_EssenceUnite_Collection Indexation_EssenceUnite_Col_IndexationID_Collection {

			get {

				if (this.internal_Indexation_EssenceUnite_Col_IndexationID_Collection == null) {

					this.internal_Indexation_EssenceUnite_Col_IndexationID_Collection = new Indexation_EssenceUnite_Collection(this.connectionString);
					this.internal_Indexation_EssenceUnite_Col_IndexationID_Collection.LoadFrom_IndexationID(this.col_ID, this);
				}

				return(this.internal_Indexation_EssenceUnite_Col_IndexationID_Collection);
			}
		}

		private Indexation_Municipalite_Collection internal_Indexation_Municipalite_Col_IndexationID_Collection = null;
		public Indexation_Municipalite_Collection Indexation_Municipalite_Col_IndexationID_Collection {

			get {

				if (this.internal_Indexation_Municipalite_Col_IndexationID_Collection == null) {

					this.internal_Indexation_Municipalite_Col_IndexationID_Collection = new Indexation_Municipalite_Collection(this.connectionString);
					this.internal_Indexation_Municipalite_Col_IndexationID_Collection.LoadFrom_IndexationID(this.col_ID, this);
				}

				return(this.internal_Indexation_Municipalite_Col_IndexationID_Collection);
			}
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_IndexationID_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_IndexationID_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_IndexationID_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_IndexationID_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_IndexationID_Collection.LoadFrom_IndexationID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_IndexationID_Collection);
			}
		}

		private IndexationCalcule_Transporteur_Collection internal_IndexationCalcule_Transporteur_Col_IndexationID_Collection = null;
		public IndexationCalcule_Transporteur_Collection IndexationCalcule_Transporteur_Col_IndexationID_Collection {

			get {

				if (this.internal_IndexationCalcule_Transporteur_Col_IndexationID_Collection == null) {

					this.internal_IndexationCalcule_Transporteur_Col_IndexationID_Collection = new IndexationCalcule_Transporteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Transporteur_Col_IndexationID_Collection.LoadFrom_IndexationID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Transporteur_Col_IndexationID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Indexation_Display Param = new Params.spS_Indexation_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Indexation_Display Sp = new SPs.spS_Indexation_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Indexation_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Indexation_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
