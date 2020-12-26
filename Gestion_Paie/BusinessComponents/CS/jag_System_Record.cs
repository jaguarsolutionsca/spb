using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [jag_System] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.jag_System_Collection"/> class to do so.
	/// </summary>
	public sealed class jag_System_Record : IBusinessComponentRecord {
	
		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the jag_System_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.jag_System_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public jag_System_Record() {
		
		}
	
		public jag_System_Record(string connectionString) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_System'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "jag_System", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.connectionString = connectionString;
		}
		
		
		internal bool col_Fournisseur_PlanConjointWasSet = false;
		internal System.Data.SqlTypes.SqlString col_Fournisseur_PlanConjoint = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Fournisseur_PlanConjoint {
		
			get {
			
				return(this.col_Fournisseur_PlanConjoint);
			}
		}

		
		private Fournisseur_Record col_Fournisseur_PlanConjoint_Record = null;
		public Fournisseur_Record Col_Fournisseur_PlanConjoint_Fournisseur_Record {
		
			get {

				if (this.col_Fournisseur_PlanConjoint_Record == null) {
				
					this.col_Fournisseur_PlanConjoint_Record = new Fournisseur_Record(this.connectionString, this.col_Fournisseur_PlanConjoint);
				}
				
				return(this.col_Fournisseur_PlanConjoint_Record);
			}
		}

		internal bool col_Fournisseur_SurchargeWasSet = false;
		internal System.Data.SqlTypes.SqlString col_Fournisseur_Surcharge = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Fournisseur_Surcharge {
		
			get {
			
				return(this.col_Fournisseur_Surcharge);
			}
		}

		
		private Fournisseur_Record col_Fournisseur_Surcharge_Record = null;
		public Fournisseur_Record Col_Fournisseur_Surcharge_Fournisseur_Record {
		
			get {

				if (this.col_Fournisseur_Surcharge_Record == null) {
				
					this.col_Fournisseur_Surcharge_Record = new Fournisseur_Record(this.connectionString, this.col_Fournisseur_Surcharge);
				}
				
				return(this.col_Fournisseur_Surcharge_Record);
			}
		}

		internal bool col_Compte_PaiementsWasSet = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_Paiements = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_Paiements {
		
			get {
			
				return(this.col_Compte_Paiements);
			}
		}

		
		private Compte_Record col_Compte_Paiements_Record = null;
		public Compte_Record Col_Compte_Paiements_Compte_Record {
		
			get {

				if (this.col_Compte_Paiements_Record == null) {
				
					this.col_Compte_Paiements_Record = new Compte_Record(this.connectionString, this.col_Compte_Paiements);
				}
				
				return(this.col_Compte_Paiements_Record);
			}
		}

		internal bool col_Compte_ARecevoirWasSet = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_ARecevoir = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_ARecevoir {
		
			get {
			
				return(this.col_Compte_ARecevoir);
			}
		}

		
		private Compte_Record col_Compte_ARecevoir_Record = null;
		public Compte_Record Col_Compte_ARecevoir_Compte_Record {
		
			get {

				if (this.col_Compte_ARecevoir_Record == null) {
				
					this.col_Compte_ARecevoir_Record = new Compte_Record(this.connectionString, this.col_Compte_ARecevoir);
				}
				
				return(this.col_Compte_ARecevoir_Record);
			}
		}

		internal bool col_Compte_APayerWasSet = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_APayer = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_APayer {
		
			get {
			
				return(this.col_Compte_APayer);
			}
		}

		
		private Compte_Record col_Compte_APayer_Record = null;
		public Compte_Record Col_Compte_APayer_Compte_Record {
		
			get {

				if (this.col_Compte_APayer_Record == null) {
				
					this.col_Compte_APayer_Record = new Compte_Record(this.connectionString, this.col_Compte_APayer);
				}
				
				return(this.col_Compte_APayer_Record);
			}
		}

		internal bool col_Compte_DuAuxProducteursWasSet = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_DuAuxProducteurs = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_DuAuxProducteurs {
		
			get {
			
				return(this.col_Compte_DuAuxProducteurs);
			}
		}

		
		private Compte_Record col_Compte_DuAuxProducteurs_Record = null;
		public Compte_Record Col_Compte_DuAuxProducteurs_Compte_Record {
		
			get {

				if (this.col_Compte_DuAuxProducteurs_Record == null) {
				
					this.col_Compte_DuAuxProducteurs_Record = new Compte_Record(this.connectionString, this.col_Compte_DuAuxProducteurs);
				}
				
				return(this.col_Compte_DuAuxProducteurs_Record);
			}
		}

		internal bool col_Compte_TPSpercuesWasSet = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_TPSpercues = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_TPSpercues {
		
			get {
			
				return(this.col_Compte_TPSpercues);
			}
		}

		
		private Compte_Record col_Compte_TPSpercues_Record = null;
		public Compte_Record Col_Compte_TPSpercues_Compte_Record {
		
			get {

				if (this.col_Compte_TPSpercues_Record == null) {
				
					this.col_Compte_TPSpercues_Record = new Compte_Record(this.connectionString, this.col_Compte_TPSpercues);
				}
				
				return(this.col_Compte_TPSpercues_Record);
			}
		}

		internal bool col_Compte_TPSpayeesWasSet = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_TPSpayees = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_TPSpayees {
		
			get {
			
				return(this.col_Compte_TPSpayees);
			}
		}

		
		private Compte_Record col_Compte_TPSpayees_Record = null;
		public Compte_Record Col_Compte_TPSpayees_Compte_Record {
		
			get {

				if (this.col_Compte_TPSpayees_Record == null) {
				
					this.col_Compte_TPSpayees_Record = new Compte_Record(this.connectionString, this.col_Compte_TPSpayees);
				}
				
				return(this.col_Compte_TPSpayees_Record);
			}
		}

		internal bool col_Compte_TVQpercuesWasSet = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_TVQpercues = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_TVQpercues {
		
			get {
			
				return(this.col_Compte_TVQpercues);
			}
		}

		
		private Compte_Record col_Compte_TVQpercues_Record = null;
		public Compte_Record Col_Compte_TVQpercues_Compte_Record {
		
			get {

				if (this.col_Compte_TVQpercues_Record == null) {
				
					this.col_Compte_TVQpercues_Record = new Compte_Record(this.connectionString, this.col_Compte_TVQpercues);
				}
				
				return(this.col_Compte_TVQpercues_Record);
			}
		}

		internal bool col_Compte_TVQpayeesWasSet = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_TVQpayees = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_TVQpayees {
		
			get {
			
				return(this.col_Compte_TVQpayees);
			}
		}

		
		private Compte_Record col_Compte_TVQpayees_Record = null;
		public Compte_Record Col_Compte_TVQpayees_Compte_Record {
		
			get {

				if (this.col_Compte_TVQpayees_Record == null) {
				
					this.col_Compte_TVQpayees_Record = new Compte_Record(this.connectionString, this.col_Compte_TVQpayees);
				}
				
				return(this.col_Compte_TVQpayees_Record);
			}
		}

		internal bool col_Taux_TPSWasSet = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_TPS = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_TPS {
		
			get {
			
				return(this.col_Taux_TPS);
			}
		}

		internal bool col_Taux_TVQWasSet = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_TVQ = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_TVQ {
		
			get {
			
				return(this.col_Taux_TVQ);
			}
		}

		internal bool col_Fournisseur_Fond_RoulementWasSet = false;
		internal System.Data.SqlTypes.SqlString col_Fournisseur_Fond_Roulement = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Fournisseur_Fond_Roulement {
		
			get {
			
				return(this.col_Fournisseur_Fond_Roulement);
			}
		}

		internal bool col_Fournisseur_Fond_ForestierWasSet = false;
		internal System.Data.SqlTypes.SqlString col_Fournisseur_Fond_Forestier = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Fournisseur_Fond_Forestier {
		
			get {
			
				return(this.col_Fournisseur_Fond_Forestier);
			}
		}

		internal bool col_Fournisseur_Preleve_DiversWasSet = false;
		internal System.Data.SqlTypes.SqlString col_Fournisseur_Preleve_Divers = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Fournisseur_Preleve_Divers {
		
			get {
			
				return(this.col_Fournisseur_Preleve_Divers);
			}
		}


		public bool Refresh() {

			throw new System.Exception("Not available because this table has no primary key.");
		}

		public void Update() {

			throw new System.Exception("Not available because this table has no primary key.");

		}

		internal string displayName = null;
		public override string ToString() {

		
			if (this.displayName == null) {
			
				Params.spS_jag_System_Display Param = new Params.spS_jag_System_Display();
				Param.SetUpConnection(this.connectionString);


				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_jag_System_Display Sp = new SPs.spS_jag_System_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_jag_System_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_jag_System_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.jag_System_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
