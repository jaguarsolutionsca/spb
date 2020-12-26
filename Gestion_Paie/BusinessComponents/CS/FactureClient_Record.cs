using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [FactureClient] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.FactureClient_Collection"/> class to do so.
	/// </summary>
	public sealed class FactureClient_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the FactureClient_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.FactureClient_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public FactureClient_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public FactureClient_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureClient'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureClient", CurrentRevision, OriginalRevision));
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
		
		internal bool col_NoFactureWasSet = false;
		private bool col_NoFactureWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NoFacture = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NoFacture {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NoFacture);
			}
			set {
			
				this.col_NoFactureWasUpdated = true;
				this.col_NoFactureWasSet = true;
				this.col_NoFacture = value;
			}
		}

		internal bool col_DateFactureWasSet = false;
		private bool col_DateFactureWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateFacture = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateFacture {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateFacture);
			}
			set {
			
				this.col_DateFactureWasUpdated = true;
				this.col_DateFactureWasSet = true;
				this.col_DateFacture = value;
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
				this.col_Annee = value;
			}
		}

		internal bool col_TypeFactureWasSet = false;
		private bool col_TypeFactureWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TypeFacture = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TypeFacture {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TypeFacture);
			}
			set {
			
				this.col_TypeFactureWasUpdated = true;
				this.col_TypeFactureWasSet = true;
				this.col_TypeFacture_Record = null;
				this.col_TypeFacture = value;
			}
		}

		
		private TypeFacture_Record col_TypeFacture_Record = null;
		public TypeFacture_Record Col_TypeFacture_TypeFacture_Record {
		
			get {

				if (this.col_TypeFacture_Record == null) {
				
					this.col_TypeFacture_Record = new TypeFacture_Record(this.connectionString, this.col_TypeFacture);
				}
				
				return(this.col_TypeFacture_Record);
			}
		}

		internal bool col_TypeInvoiceClientAcombaWasSet = false;
		private bool col_TypeInvoiceClientAcombaWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_TypeInvoiceClientAcomba = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_TypeInvoiceClientAcomba {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TypeInvoiceClientAcomba);
			}
			set {
			
				this.col_TypeInvoiceClientAcombaWasUpdated = true;
				this.col_TypeInvoiceClientAcombaWasSet = true;
				this.col_TypeInvoiceClientAcomba_Record = null;
				this.col_TypeInvoiceClientAcomba = value;
			}
		}

		
		private TypeInvoiceClientAcomba_Record col_TypeInvoiceClientAcomba_Record = null;
		public TypeInvoiceClientAcomba_Record Col_TypeInvoiceClientAcomba_TypeInvoiceClientAcomba_Record {
		
			get {

				if (this.col_TypeInvoiceClientAcomba_Record == null) {
				
					this.col_TypeInvoiceClientAcomba_Record = new TypeInvoiceClientAcomba_Record(this.connectionString, this.col_TypeInvoiceClientAcomba);
				}
				
				return(this.col_TypeInvoiceClientAcomba_Record);
			}
		}

		internal bool col_ClientIDWasSet = false;
		private bool col_ClientIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ClientID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ClientID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ClientID);
			}
			set {
			
				this.col_ClientIDWasUpdated = true;
				this.col_ClientIDWasSet = true;
				this.col_ClientID_Record = null;
				this.col_ClientID = value;
			}
		}

		
		private Usine_Record col_ClientID_Record = null;
		public Usine_Record Col_ClientID_Usine_Record {
		
			get {

				if (this.col_ClientID_Record == null) {
				
					this.col_ClientID_Record = new Usine_Record(this.connectionString, this.col_ClientID);
				}
				
				return(this.col_ClientID_Record);
			}
		}

		internal bool col_PayerAIDWasSet = false;
		private bool col_PayerAIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_PayerAID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_PayerAID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PayerAID);
			}
			set {
			
				this.col_PayerAIDWasUpdated = true;
				this.col_PayerAIDWasSet = true;
				this.col_PayerAID_Record = null;
				this.col_PayerAID = value;
			}
		}

		
		private Usine_Record col_PayerAID_Record = null;
		public Usine_Record Col_PayerAID_Usine_Record {
		
			get {

				if (this.col_PayerAID_Record == null) {
				
					this.col_PayerAID_Record = new Usine_Record(this.connectionString, this.col_PayerAID);
				}
				
				return(this.col_PayerAID_Record);
			}
		}

		internal bool col_Montant_TotalWasSet = false;
		private bool col_Montant_TotalWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Total = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Total {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Total);
			}
			set {
			
				this.col_Montant_TotalWasUpdated = true;
				this.col_Montant_TotalWasSet = true;
				this.col_Montant_Total = value;
			}
		}

		internal bool col_Montant_TPSWasSet = false;
		private bool col_Montant_TPSWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_TPS = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_TPS {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_TPS);
			}
			set {
			
				this.col_Montant_TPSWasUpdated = true;
				this.col_Montant_TPSWasSet = true;
				this.col_Montant_TPS = value;
			}
		}

		internal bool col_Montant_TVQWasSet = false;
		private bool col_Montant_TVQWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_TVQ = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_TVQ {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_TVQ);
			}
			set {
			
				this.col_Montant_TVQWasUpdated = true;
				this.col_Montant_TVQWasSet = true;
				this.col_Montant_TVQ = value;
			}
		}

		internal bool col_DescriptionWasSet = false;
		private bool col_DescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Description = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Description {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Description);
			}
			set {
			
				this.col_DescriptionWasUpdated = true;
				this.col_DescriptionWasSet = true;
				this.col_Description = value;
			}
		}

		internal bool col_StatusWasSet = false;
		private bool col_StatusWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Status = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Status {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Status);
			}
			set {
			
				this.col_StatusWasUpdated = true;
				this.col_StatusWasSet = true;
				this.col_Status_Record = null;
				this.col_Status = value;
			}
		}

		
		private FactureStatus_Record col_Status_Record = null;
		public FactureStatus_Record Col_Status_FactureStatus_Record {
		
			get {

				if (this.col_Status_Record == null) {
				
					this.col_Status_Record = new FactureStatus_Record(this.connectionString, this.col_Status);
				}
				
				return(this.col_Status_Record);
			}
		}

		internal bool col_StatusDescriptionWasSet = false;
		private bool col_StatusDescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_StatusDescription = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_StatusDescription {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_StatusDescription);
			}
			set {
			
				this.col_StatusDescriptionWasUpdated = true;
				this.col_StatusDescriptionWasSet = true;
				this.col_StatusDescription = value;
			}
		}

		internal bool col_DateFactureAcombaWasSet = false;
		private bool col_DateFactureAcombaWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateFactureAcomba = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateFactureAcomba {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateFactureAcomba);
			}
			set {
			
				this.col_DateFactureAcombaWasUpdated = true;
				this.col_DateFactureAcombaWasSet = true;
				this.col_DateFactureAcomba = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_NoFactureWasUpdated = false;
			this.col_NoFactureWasSet = false;
			this.col_NoFacture = System.Data.SqlTypes.SqlString.Null;

			this.col_DateFactureWasUpdated = false;
			this.col_DateFactureWasSet = false;
			this.col_DateFacture = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_AnneeWasUpdated = false;
			this.col_AnneeWasSet = false;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;

			this.col_TypeFactureWasUpdated = false;
			this.col_TypeFactureWasSet = false;
			this.col_TypeFacture = System.Data.SqlTypes.SqlString.Null;

			this.col_TypeInvoiceClientAcombaWasUpdated = false;
			this.col_TypeInvoiceClientAcombaWasSet = false;
			this.col_TypeInvoiceClientAcomba = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ClientIDWasUpdated = false;
			this.col_ClientIDWasSet = false;
			this.col_ClientID = System.Data.SqlTypes.SqlString.Null;

			this.col_PayerAIDWasUpdated = false;
			this.col_PayerAIDWasSet = false;
			this.col_PayerAID = System.Data.SqlTypes.SqlString.Null;

			this.col_Montant_TotalWasUpdated = false;
			this.col_Montant_TotalWasSet = false;
			this.col_Montant_Total = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_TPSWasUpdated = false;
			this.col_Montant_TPSWasSet = false;
			this.col_Montant_TPS = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_TVQWasUpdated = false;
			this.col_Montant_TVQWasSet = false;
			this.col_Montant_TVQ = System.Data.SqlTypes.SqlDouble.Null;

			this.col_DescriptionWasUpdated = false;
			this.col_DescriptionWasSet = false;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;

			this.col_StatusWasUpdated = false;
			this.col_StatusWasSet = false;
			this.col_Status = System.Data.SqlTypes.SqlString.Null;

			this.col_StatusDescriptionWasUpdated = false;
			this.col_StatusDescriptionWasSet = false;
			this.col_StatusDescription = System.Data.SqlTypes.SqlString.Null;

			this.col_DateFactureAcombaWasUpdated = false;
			this.col_DateFactureAcombaWasSet = false;
			this.col_DateFactureAcomba = System.Data.SqlTypes.SqlDateTime.Null;

			Params.spS_FactureClient Param = new Params.spS_FactureClient(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureClient Sp = new SPs.spS_FactureClient();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_NoFacture.ColumnIndex)) {

						this.col_NoFacture = sqlDataReader.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_NoFacture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_DateFacture.ColumnIndex)) {

						this.col_DateFacture = sqlDataReader.GetSqlDateTime(SPs.spS_FactureClient.Resultset1.Fields.Column_DateFacture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = sqlDataReader.GetSqlInt32(SPs.spS_FactureClient.Resultset1.Fields.Column_Annee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_TypeFacture.ColumnIndex)) {

						this.col_TypeFacture = sqlDataReader.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_TypeFacture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_TypeInvoiceClientAcomba.ColumnIndex)) {

						this.col_TypeInvoiceClientAcomba = sqlDataReader.GetSqlInt32(SPs.spS_FactureClient.Resultset1.Fields.Column_TypeInvoiceClientAcomba.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_ClientID.ColumnIndex)) {

						this.col_ClientID = sqlDataReader.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_ClientID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_PayerAID.ColumnIndex)) {

						this.col_PayerAID = sqlDataReader.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_PayerAID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_Total.ColumnIndex)) {

						this.col_Montant_Total = sqlDataReader.GetSqlDouble(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_Total.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_TPS.ColumnIndex)) {

						this.col_Montant_TPS = sqlDataReader.GetSqlDouble(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_TPS.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_TVQ.ColumnIndex)) {

						this.col_Montant_TVQ = sqlDataReader.GetSqlDouble(SPs.spS_FactureClient.Resultset1.Fields.Column_Montant_TVQ.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_Description.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_Status.ColumnIndex)) {

						this.col_Status = sqlDataReader.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_Status.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_StatusDescription.ColumnIndex)) {

						this.col_StatusDescription = sqlDataReader.GetSqlString(SPs.spS_FactureClient.Resultset1.Fields.Column_StatusDescription.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient.Resultset1.Fields.Column_DateFactureAcomba.ColumnIndex)) {

						this.col_DateFactureAcomba = sqlDataReader.GetSqlDateTime(SPs.spS_FactureClient.Resultset1.Fields.Column_DateFactureAcomba.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureClient_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NoFactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateFactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AnneeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TypeFactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TypeInvoiceClientAcombaWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ClientIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PayerAIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_TotalWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_TPSWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_TVQWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_StatusWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_StatusDescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateFactureAcombaWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_FactureClient Param = new Params.spU_FactureClient(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_NoFactureWasUpdated) {

				Param.Param_NoFacture = this.col_NoFacture;
				Param.Param_ConsiderNull_NoFacture = true;
			}

			if (this.col_DateFactureWasUpdated) {

				Param.Param_DateFacture = this.col_DateFacture;
				Param.Param_ConsiderNull_DateFacture = true;
			}

			if (this.col_AnneeWasUpdated) {

				Param.Param_Annee = this.col_Annee;
				Param.Param_ConsiderNull_Annee = true;
			}

			if (this.col_TypeFactureWasUpdated) {

				Param.Param_TypeFacture = this.col_TypeFacture;
				Param.Param_ConsiderNull_TypeFacture = true;
			}

			if (this.col_TypeInvoiceClientAcombaWasUpdated) {

				Param.Param_TypeInvoiceClientAcomba = this.col_TypeInvoiceClientAcomba;
				Param.Param_ConsiderNull_TypeInvoiceClientAcomba = true;
			}

			if (this.col_ClientIDWasUpdated) {

				Param.Param_ClientID = this.col_ClientID;
				Param.Param_ConsiderNull_ClientID = true;
			}

			if (this.col_PayerAIDWasUpdated) {

				Param.Param_PayerAID = this.col_PayerAID;
				Param.Param_ConsiderNull_PayerAID = true;
			}

			if (this.col_Montant_TotalWasUpdated) {

				Param.Param_Montant_Total = this.col_Montant_Total;
				Param.Param_ConsiderNull_Montant_Total = true;
			}

			if (this.col_Montant_TPSWasUpdated) {

				Param.Param_Montant_TPS = this.col_Montant_TPS;
				Param.Param_ConsiderNull_Montant_TPS = true;
			}

			if (this.col_Montant_TVQWasUpdated) {

				Param.Param_Montant_TVQ = this.col_Montant_TVQ;
				Param.Param_ConsiderNull_Montant_TVQ = true;
			}

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			if (this.col_StatusWasUpdated) {

				Param.Param_Status = this.col_Status;
				Param.Param_ConsiderNull_Status = true;
			}

			if (this.col_StatusDescriptionWasUpdated) {

				Param.Param_StatusDescription = this.col_StatusDescription;
				Param.Param_ConsiderNull_StatusDescription = true;
			}

			if (this.col_DateFactureAcombaWasUpdated) {

				Param.Param_DateFactureAcomba = this.col_DateFactureAcomba;
				Param.Param_ConsiderNull_DateFactureAcomba = true;
			}

			SPs.spU_FactureClient Sp = new SPs.spU_FactureClient();
			if (Sp.Execute(ref Param)) {

				this.col_NoFactureWasUpdated = false;
				this.col_DateFactureWasUpdated = false;
				this.col_AnneeWasUpdated = false;
				this.col_TypeFactureWasUpdated = false;
				this.col_TypeInvoiceClientAcombaWasUpdated = false;
				this.col_ClientIDWasUpdated = false;
				this.col_PayerAIDWasUpdated = false;
				this.col_Montant_TotalWasUpdated = false;
				this.col_Montant_TPSWasUpdated = false;
				this.col_Montant_TVQWasUpdated = false;
				this.col_DescriptionWasUpdated = false;
				this.col_StatusWasUpdated = false;
				this.col_StatusDescriptionWasUpdated = false;
				this.col_DateFactureAcombaWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureClient_Record", "Update");
			}		
		}

		private AjustementCalcule_Usine_Collection internal_AjustementCalcule_Usine_Col_FactureID_Collection = null;
		public AjustementCalcule_Usine_Collection AjustementCalcule_Usine_Col_FactureID_Collection {

			get {

				if (this.internal_AjustementCalcule_Usine_Col_FactureID_Collection == null) {

					this.internal_AjustementCalcule_Usine_Col_FactureID_Collection = new AjustementCalcule_Usine_Collection(this.connectionString);
					this.internal_AjustementCalcule_Usine_Col_FactureID_Collection.LoadFrom_FactureID(this.col_ID, this);
				}

				return(this.internal_AjustementCalcule_Usine_Col_FactureID_Collection);
			}
		}

		private FactureClient_Details_Collection internal_FactureClient_Details_Col_FactureID_Collection = null;
		public FactureClient_Details_Collection FactureClient_Details_Col_FactureID_Collection {

			get {

				if (this.internal_FactureClient_Details_Col_FactureID_Collection == null) {

					this.internal_FactureClient_Details_Col_FactureID_Collection = new FactureClient_Details_Collection(this.connectionString);
					this.internal_FactureClient_Details_Col_FactureID_Collection.LoadFrom_FactureID(this.col_ID, this);
				}

				return(this.internal_FactureClient_Details_Col_FactureID_Collection);
			}
		}

		private FactureClient_Sommaire_Collection internal_FactureClient_Sommaire_Col_FactureID_Collection = null;
		public FactureClient_Sommaire_Collection FactureClient_Sommaire_Col_FactureID_Collection {

			get {

				if (this.internal_FactureClient_Sommaire_Col_FactureID_Collection == null) {

					this.internal_FactureClient_Sommaire_Col_FactureID_Collection = new FactureClient_Sommaire_Collection(this.connectionString);
					this.internal_FactureClient_Sommaire_Col_FactureID_Collection.LoadFrom_FactureID(this.col_ID, this);
				}

				return(this.internal_FactureClient_Sommaire_Col_FactureID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_Usine_FactureID_Collection = null;
		public Livraison_Collection Livraison_Col_Usine_FactureID_Collection {

			get {

				if (this.internal_Livraison_Col_Usine_FactureID_Collection == null) {

					this.internal_Livraison_Col_Usine_FactureID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_Usine_FactureID_Collection.LoadFrom_Usine_FactureID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_Usine_FactureID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_FactureClient_Display Param = new Params.spS_FactureClient_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_FactureClient_Display Sp = new SPs.spS_FactureClient_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_FactureClient_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_FactureClient_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureClient_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
