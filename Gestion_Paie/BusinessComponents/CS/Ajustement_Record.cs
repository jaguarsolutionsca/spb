using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Ajustement] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Ajustement_Collection"/> class to do so.
	/// </summary>
	public sealed class Ajustement_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Ajustement_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Ajustement_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Ajustement_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Ajustement_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Ajustement", CurrentRevision, OriginalRevision));
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

		internal bool col_DateAjustementWasSet = false;
		private bool col_DateAjustementWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateAjustement = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateAjustement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateAjustement);
			}
			set {
			
				this.col_DateAjustementWasUpdated = true;
				this.col_DateAjustementWasSet = true;
				this.col_DateAjustement = value;
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

		internal bool col_UsePeriodesWasSet = false;
		private bool col_UsePeriodesWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_UsePeriodes = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_UsePeriodes {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UsePeriodes);
			}
			set {
			
				this.col_UsePeriodesWasUpdated = true;
				this.col_UsePeriodesWasSet = true;
				this.col_UsePeriodes = value;
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

		internal bool col_TransporteurIDWasSet = false;
		private bool col_TransporteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TransporteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TransporteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TransporteurID);
			}
			set {
			
				this.col_TransporteurIDWasUpdated = true;
				this.col_TransporteurIDWasSet = true;
				this.col_TransporteurID = value;
			}
		}

		internal bool col_IsRistourneWasSet = false;
		private bool col_IsRistourneWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_IsRistourne = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_IsRistourne {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IsRistourne);
			}
			set {
			
				this.col_IsRistourneWasUpdated = true;
				this.col_IsRistourneWasSet = true;
				this.col_IsRistourne = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_DateAjustementWasUpdated = false;
			this.col_DateAjustementWasSet = false;
			this.col_DateAjustement = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_Periode_DebutWasUpdated = false;
			this.col_Periode_DebutWasSet = false;
			this.col_Periode_Debut = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Periode_FinWasUpdated = false;
			this.col_Periode_FinWasSet = false;
			this.col_Periode_Fin = System.Data.SqlTypes.SqlInt32.Null;

			this.col_FactureWasUpdated = false;
			this.col_FactureWasSet = false;
			this.col_Facture = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_UsePeriodesWasUpdated = false;
			this.col_UsePeriodesWasSet = false;
			this.col_UsePeriodes = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Date_DebutWasUpdated = false;
			this.col_Date_DebutWasSet = false;
			this.col_Date_Debut = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_Date_FinWasUpdated = false;
			this.col_Date_FinWasSet = false;
			this.col_Date_Fin = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_ProducteurIDWasUpdated = false;
			this.col_ProducteurIDWasSet = false;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_TransporteurIDWasUpdated = false;
			this.col_TransporteurIDWasSet = false;
			this.col_TransporteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_IsRistourneWasUpdated = false;
			this.col_IsRistourneWasSet = false;
			this.col_IsRistourne = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Ajustement Param = new Params.spS_Ajustement(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Ajustement Sp = new SPs.spS_Ajustement();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_Ajustement.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_DateAjustement.ColumnIndex)) {

						this.col_DateAjustement = sqlDataReader.GetSqlDateTime(SPs.spS_Ajustement.Resultset1.Fields.Column_DateAjustement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Periode_Debut.ColumnIndex)) {

						this.col_Periode_Debut = sqlDataReader.GetSqlInt32(SPs.spS_Ajustement.Resultset1.Fields.Column_Periode_Debut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Periode_Fin.ColumnIndex)) {

						this.col_Periode_Fin = sqlDataReader.GetSqlInt32(SPs.spS_Ajustement.Resultset1.Fields.Column_Periode_Fin.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Facture.ColumnIndex)) {

						this.col_Facture = sqlDataReader.GetSqlBoolean(SPs.spS_Ajustement.Resultset1.Fields.Column_Facture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_UsePeriodes.ColumnIndex)) {

						this.col_UsePeriodes = sqlDataReader.GetSqlBoolean(SPs.spS_Ajustement.Resultset1.Fields.Column_UsePeriodes.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Date_Debut.ColumnIndex)) {

						this.col_Date_Debut = sqlDataReader.GetSqlDateTime(SPs.spS_Ajustement.Resultset1.Fields.Column_Date_Debut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_Date_Fin.ColumnIndex)) {

						this.col_Date_Fin = sqlDataReader.GetSqlDateTime(SPs.spS_Ajustement.Resultset1.Fields.Column_Date_Fin.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = sqlDataReader.GetSqlString(SPs.spS_Ajustement.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_TransporteurID.ColumnIndex)) {

						this.col_TransporteurID = sqlDataReader.GetSqlString(SPs.spS_Ajustement.Resultset1.Fields.Column_TransporteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement.Resultset1.Fields.Column_IsRistourne.ColumnIndex)) {

						this.col_IsRistourne = sqlDataReader.GetSqlBoolean(SPs.spS_Ajustement.Resultset1.Fields.Column_IsRistourne.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Ajustement_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateAjustementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Periode_DebutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Periode_FinWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UsePeriodesWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Date_DebutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Date_FinWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TransporteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IsRistourneWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Ajustement Param = new Params.spU_Ajustement(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_DateAjustementWasUpdated) {

				Param.Param_DateAjustement = this.col_DateAjustement;
				Param.Param_ConsiderNull_DateAjustement = true;
			}

			if (this.col_Periode_DebutWasUpdated) {

				Param.Param_Periode_Debut = this.col_Periode_Debut;
				Param.Param_ConsiderNull_Periode_Debut = true;
			}

			if (this.col_Periode_FinWasUpdated) {

				Param.Param_Periode_Fin = this.col_Periode_Fin;
				Param.Param_ConsiderNull_Periode_Fin = true;
			}

			if (this.col_FactureWasUpdated) {

				Param.Param_Facture = this.col_Facture;
				Param.Param_ConsiderNull_Facture = true;
			}

			if (this.col_UsePeriodesWasUpdated) {

				Param.Param_UsePeriodes = this.col_UsePeriodes;
				Param.Param_ConsiderNull_UsePeriodes = true;
			}

			if (this.col_Date_DebutWasUpdated) {

				Param.Param_Date_Debut = this.col_Date_Debut;
				Param.Param_ConsiderNull_Date_Debut = true;
			}

			if (this.col_Date_FinWasUpdated) {

				Param.Param_Date_Fin = this.col_Date_Fin;
				Param.Param_ConsiderNull_Date_Fin = true;
			}

			if (this.col_ProducteurIDWasUpdated) {

				Param.Param_ProducteurID = this.col_ProducteurID;
				Param.Param_ConsiderNull_ProducteurID = true;
			}

			if (this.col_TransporteurIDWasUpdated) {

				Param.Param_TransporteurID = this.col_TransporteurID;
				Param.Param_ConsiderNull_TransporteurID = true;
			}

			if (this.col_IsRistourneWasUpdated) {

				Param.Param_IsRistourne = this.col_IsRistourne;
				Param.Param_ConsiderNull_IsRistourne = true;
			}

			SPs.spU_Ajustement Sp = new SPs.spU_Ajustement();
			if (Sp.Execute(ref Param)) {

				this.col_ContratIDWasUpdated = false;
				this.col_DateAjustementWasUpdated = false;
				this.col_Periode_DebutWasUpdated = false;
				this.col_Periode_FinWasUpdated = false;
				this.col_FactureWasUpdated = false;
				this.col_UsePeriodesWasUpdated = false;
				this.col_Date_DebutWasUpdated = false;
				this.col_Date_FinWasUpdated = false;
				this.col_ProducteurIDWasUpdated = false;
				this.col_TransporteurIDWasUpdated = false;
				this.col_IsRistourneWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Ajustement_Record", "Update");
			}		
		}

		private Ajustement_EssenceUnite_Collection internal_Ajustement_EssenceUnite_Col_AjustementID_Collection = null;
		public Ajustement_EssenceUnite_Collection Ajustement_EssenceUnite_Col_AjustementID_Collection {

			get {

				if (this.internal_Ajustement_EssenceUnite_Col_AjustementID_Collection == null) {

					this.internal_Ajustement_EssenceUnite_Col_AjustementID_Collection = new Ajustement_EssenceUnite_Collection(this.connectionString);
					this.internal_Ajustement_EssenceUnite_Col_AjustementID_Collection.LoadFrom_AjustementID(this.col_ID, this);
				}

				return(this.internal_Ajustement_EssenceUnite_Col_AjustementID_Collection);
			}
		}

		private Ajustement_Transporteur_Collection internal_Ajustement_Transporteur_Col_AjustementID_Collection = null;
		public Ajustement_Transporteur_Collection Ajustement_Transporteur_Col_AjustementID_Collection {

			get {

				if (this.internal_Ajustement_Transporteur_Col_AjustementID_Collection == null) {

					this.internal_Ajustement_Transporteur_Col_AjustementID_Collection = new Ajustement_Transporteur_Collection(this.connectionString);
					this.internal_Ajustement_Transporteur_Col_AjustementID_Collection.LoadFrom_AjustementID(this.col_ID, this);
				}

				return(this.internal_Ajustement_Transporteur_Col_AjustementID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Ajustement_Display Param = new Params.spS_Ajustement_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Ajustement_Display Sp = new SPs.spS_Ajustement_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Ajustement_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Ajustement_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Ajustement_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
