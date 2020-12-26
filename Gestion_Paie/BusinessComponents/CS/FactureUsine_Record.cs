using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [FactureUsine] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.FactureUsine_Collection"/> class to do so.
	/// </summary>
	public sealed class FactureUsine_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the FactureUsine_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.FactureUsine_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public FactureUsine_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public FactureUsine_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureUsine", CurrentRevision, OriginalRevision));
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
		
		internal bool col_DatePermisWasSet = false;
		private bool col_DatePermisWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DatePermis = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DatePermis {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DatePermis);
			}
			set {
			
				this.col_DatePermisWasUpdated = true;
				this.col_DatePermisWasSet = true;
				this.col_DatePermis = value;
			}
		}

		internal bool col_DateLivraisonWasSet = false;
		private bool col_DateLivraisonWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateLivraison {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateLivraison);
			}
			set {
			
				this.col_DateLivraisonWasUpdated = true;
				this.col_DateLivraisonWasSet = true;
				this.col_DateLivraison = value;
			}
		}

		internal bool col_DatePayeWasSet = false;
		private bool col_DatePayeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DatePaye {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DatePaye);
			}
			set {
			
				this.col_DatePayeWasUpdated = true;
				this.col_DatePayeWasSet = true;
				this.col_DatePaye = value;
			}
		}

		internal bool col_AnneeWasSet = false;
		private bool col_AnneeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Annee);
			}
			set {
			
				this.col_AnneeWasUpdated = true;
				this.col_AnneeWasSet = true;
				this.col_Annee_Record = null;
				this.col_Annee = value;
			}
		}

		
		private Periode_Record col_Annee_Record = null;
		public Periode_Record Col_Annee_Periode_Record {
		
			get {

				if (this.col_Annee_Record == null) {
				
					this.col_Annee_Record = new Periode_Record(this.connectionString, this.col_Annee, System.Data.SqlTypes.SqlInt32.Null);
				}
				
				return(this.col_Annee_Record);
			}
		}

		internal bool col_PeriodeWasSet = false;
		private bool col_PeriodeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Periode = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Periode {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Periode);
			}
			set {
			
				this.col_PeriodeWasUpdated = true;
				this.col_PeriodeWasSet = true;
				this.col_Periode_Record = null;
				this.col_Periode = value;
			}
		}

		
		private Periode_Record col_Periode_Record = null;
		public Periode_Record Col_Periode_Periode_Record {
		
			get {

				if (this.col_Periode_Record == null) {
				
					this.col_Periode_Record = new Periode_Record(this.connectionString, System.Data.SqlTypes.SqlInt32.Null, this.col_Periode);
				}
				
				return(this.col_Periode_Record);
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

		internal bool col_SciageWasSet = false;
		private bool col_SciageWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Sciage {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Sciage);
			}
			set {
			
				this.col_SciageWasUpdated = true;
				this.col_SciageWasSet = true;
				this.col_Sciage = value;
			}
		}

		internal bool col_EssenceSciageWasSet = false;
		private bool col_EssenceSciageWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_EssenceSciage = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceSciage {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_EssenceSciage);
			}
			set {
			
				this.col_EssenceSciageWasUpdated = true;
				this.col_EssenceSciageWasSet = true;
				this.col_EssenceSciage = value;
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

		internal bool col_ProducteurIDWasSet = false;
		private bool col_ProducteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProducteurID);
			}
			set {
			
				this.col_ProducteurIDWasUpdated = true;
				this.col_ProducteurIDWasSet = true;
				this.col_ProducteurID = value;
			}
		}

		internal bool col_LivraisonWasSet = false;
		private bool col_LivraisonWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Livraison = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Livraison {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Livraison);
			}
			set {
			
				this.col_LivraisonWasUpdated = true;
				this.col_LivraisonWasSet = true;
				this.col_Livraison = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_DatePermisWasUpdated = false;
			this.col_DatePermisWasSet = false;
			this.col_DatePermis = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_DateLivraisonWasUpdated = false;
			this.col_DateLivraisonWasSet = false;
			this.col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_DatePayeWasUpdated = false;
			this.col_DatePayeWasSet = false;
			this.col_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_AnneeWasUpdated = false;
			this.col_AnneeWasSet = false;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;

			this.col_PeriodeWasUpdated = false;
			this.col_PeriodeWasSet = false;
			this.col_Periode = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_SciageWasUpdated = false;
			this.col_SciageWasSet = false;
			this.col_Sciage = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_EssenceSciageWasUpdated = false;
			this.col_EssenceSciageWasSet = false;
			this.col_EssenceSciage = System.Data.SqlTypes.SqlString.Null;

			this.col_NumeroFactureUsineWasUpdated = false;
			this.col_NumeroFactureUsineWasSet = false;
			this.col_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;

			this.col_ProducteurIDWasUpdated = false;
			this.col_ProducteurIDWasSet = false;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_LivraisonWasUpdated = false;
			this.col_LivraisonWasSet = false;
			this.col_Livraison = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_FactureUsine Param = new Params.spS_FactureUsine(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureUsine Sp = new SPs.spS_FactureUsine();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_DatePermis.ColumnIndex)) {

						this.col_DatePermis = sqlDataReader.GetSqlDateTime(SPs.spS_FactureUsine.Resultset1.Fields.Column_DatePermis.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_DateLivraison.ColumnIndex)) {

						this.col_DateLivraison = sqlDataReader.GetSqlDateTime(SPs.spS_FactureUsine.Resultset1.Fields.Column_DateLivraison.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_DatePaye.ColumnIndex)) {

						this.col_DatePaye = sqlDataReader.GetSqlDateTime(SPs.spS_FactureUsine.Resultset1.Fields.Column_DatePaye.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = sqlDataReader.GetSqlInt32(SPs.spS_FactureUsine.Resultset1.Fields.Column_Annee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_Periode.ColumnIndex)) {

						this.col_Periode = sqlDataReader.GetSqlInt32(SPs.spS_FactureUsine.Resultset1.Fields.Column_Periode.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_FactureUsine.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_Sciage.ColumnIndex)) {

						this.col_Sciage = sqlDataReader.GetSqlBoolean(SPs.spS_FactureUsine.Resultset1.Fields.Column_Sciage.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_EssenceSciage.ColumnIndex)) {

						this.col_EssenceSciage = sqlDataReader.GetSqlString(SPs.spS_FactureUsine.Resultset1.Fields.Column_EssenceSciage.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex)) {

						this.col_NumeroFactureUsine = sqlDataReader.GetSqlString(SPs.spS_FactureUsine.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = sqlDataReader.GetSqlString(SPs.spS_FactureUsine.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine.Resultset1.Fields.Column_Livraison.ColumnIndex)) {

						this.col_Livraison = sqlDataReader.GetSqlBoolean(SPs.spS_FactureUsine.Resultset1.Fields.Column_Livraison.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DatePermisWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateLivraisonWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DatePayeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AnneeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PeriodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_SciageWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceSciageWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NumeroFactureUsineWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LivraisonWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_FactureUsine Param = new Params.spU_FactureUsine(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DatePermisWasUpdated) {

				Param.Param_DatePermis = this.col_DatePermis;
				Param.Param_ConsiderNull_DatePermis = true;
			}

			if (this.col_DateLivraisonWasUpdated) {

				Param.Param_DateLivraison = this.col_DateLivraison;
				Param.Param_ConsiderNull_DateLivraison = true;
			}

			if (this.col_DatePayeWasUpdated) {

				Param.Param_DatePaye = this.col_DatePaye;
				Param.Param_ConsiderNull_DatePaye = true;
			}

			if (this.col_AnneeWasUpdated) {

				Param.Param_Annee = this.col_Annee;
				Param.Param_ConsiderNull_Annee = true;
			}

			if (this.col_PeriodeWasUpdated) {

				Param.Param_Periode = this.col_Periode;
				Param.Param_ConsiderNull_Periode = true;
			}

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_SciageWasUpdated) {

				Param.Param_Sciage = this.col_Sciage;
				Param.Param_ConsiderNull_Sciage = true;
			}

			if (this.col_EssenceSciageWasUpdated) {

				Param.Param_EssenceSciage = this.col_EssenceSciage;
				Param.Param_ConsiderNull_EssenceSciage = true;
			}

			if (this.col_NumeroFactureUsineWasUpdated) {

				Param.Param_NumeroFactureUsine = this.col_NumeroFactureUsine;
				Param.Param_ConsiderNull_NumeroFactureUsine = true;
			}

			if (this.col_ProducteurIDWasUpdated) {

				Param.Param_ProducteurID = this.col_ProducteurID;
				Param.Param_ConsiderNull_ProducteurID = true;
			}

			if (this.col_LivraisonWasUpdated) {

				Param.Param_Livraison = this.col_Livraison;
				Param.Param_ConsiderNull_Livraison = true;
			}

			SPs.spU_FactureUsine Sp = new SPs.spU_FactureUsine();
			if (Sp.Execute(ref Param)) {

				this.col_DatePermisWasUpdated = false;
				this.col_DateLivraisonWasUpdated = false;
				this.col_DatePayeWasUpdated = false;
				this.col_AnneeWasUpdated = false;
				this.col_PeriodeWasUpdated = false;
				this.col_ContratIDWasUpdated = false;
				this.col_SciageWasUpdated = false;
				this.col_EssenceSciageWasUpdated = false;
				this.col_NumeroFactureUsineWasUpdated = false;
				this.col_ProducteurIDWasUpdated = false;
				this.col_LivraisonWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Record", "Update");
			}		
		}

		private FactureUsine_Detail_Collection internal_FactureUsine_Detail_Col_FactureUsineID_Collection = null;
		public FactureUsine_Detail_Collection FactureUsine_Detail_Col_FactureUsineID_Collection {

			get {

				if (this.internal_FactureUsine_Detail_Col_FactureUsineID_Collection == null) {

					this.internal_FactureUsine_Detail_Col_FactureUsineID_Collection = new FactureUsine_Detail_Collection(this.connectionString);
					this.internal_FactureUsine_Detail_Col_FactureUsineID_Collection.LoadFrom_FactureUsineID(this.col_ID, this);
				}

				return(this.internal_FactureUsine_Detail_Col_FactureUsineID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_FactureUsine_Display Param = new Params.spS_FactureUsine_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_FactureUsine_Display Sp = new SPs.spS_FactureUsine_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_FactureUsine_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_FactureUsine_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
