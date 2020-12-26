using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Cert_Proprietaire] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Cert_Proprietaire_Collection"/> class to do so.
	/// </summary>
	public sealed class Cert_Proprietaire_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Cert_Proprietaire_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Cert_Proprietaire_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Cert_Proprietaire_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_Agence">[To be supplied.]</param>
		/// <param name="col_NO_ACT">[To be supplied.]</param>
		public Cert_Proprietaire_Record(string connectionString, System.Data.SqlTypes.SqlString col_Agence, System.Data.SqlTypes.SqlString col_NO_ACT) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Cert_Proprietaire'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Cert_Proprietaire", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_Agence = col_Agence;
			this.col_NO_ACT = col_NO_ACT;
		}
		
		internal System.Data.SqlTypes.SqlString col_Agence = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Agence {
		
			get {
			
				return(this.col_Agence);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Agence = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_NO_ACT = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NO_ACT {
		
			get {
			
				return(this.col_NO_ACT);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_NO_ACT = value;
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

		internal bool col_RepresentantWasSet = false;
		private bool col_RepresentantWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Representant = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Representant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Representant);
			}
			set {
			
				this.col_RepresentantWasUpdated = true;
				this.col_RepresentantWasSet = true;
				this.col_Representant = value;
			}
		}

		internal bool col_ADRESSEWasSet = false;
		private bool col_ADRESSEWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ADRESSE = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ADRESSE {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ADRESSE);
			}
			set {
			
				this.col_ADRESSEWasUpdated = true;
				this.col_ADRESSEWasSet = true;
				this.col_ADRESSE = value;
			}
		}

		internal bool col_VilleWasSet = false;
		private bool col_VilleWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Ville = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Ville {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Ville);
			}
			set {
			
				this.col_VilleWasUpdated = true;
				this.col_VilleWasSet = true;
				this.col_Ville = value;
			}
		}

		internal bool col_CODE_POSTWasSet = false;
		private bool col_CODE_POSTWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_CODE_POST = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_CODE_POST {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_CODE_POST);
			}
			set {
			
				this.col_CODE_POSTWasUpdated = true;
				this.col_CODE_POSTWasSet = true;
				this.col_CODE_POST = value;
			}
		}

		internal bool col_TEL_RESWasSet = false;
		private bool col_TEL_RESWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TEL_RES = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TEL_RES {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TEL_RES);
			}
			set {
			
				this.col_TEL_RESWasUpdated = true;
				this.col_TEL_RESWasSet = true;
				this.col_TEL_RES = value;
			}
		}

		internal bool col_TEL_BURWasSet = false;
		private bool col_TEL_BURWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TEL_BUR = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TEL_BUR {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TEL_BUR);
			}
			set {
			
				this.col_TEL_BURWasUpdated = true;
				this.col_TEL_BURWasSet = true;
				this.col_TEL_BUR = value;
			}
		}

		internal bool col_FournisseurIDWasSet = false;
		private bool col_FournisseurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_FournisseurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_FournisseurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_FournisseurID);
			}
			set {
			
				this.col_FournisseurIDWasUpdated = true;
				this.col_FournisseurIDWasSet = true;
				this.col_FournisseurID_Record = null;
				this.col_FournisseurID = value;
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

		internal bool col_FournisseurNomWasSet = false;
		private bool col_FournisseurNomWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_FournisseurNom = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_FournisseurNom {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_FournisseurNom);
			}
			set {
			
				this.col_FournisseurNomWasUpdated = true;
				this.col_FournisseurNomWasSet = true;
				this.col_FournisseurNom = value;
			}
		}

		internal bool col_TraiteWasSet = false;
		private bool col_TraiteWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Traite = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Traite {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Traite);
			}
			set {
			
				this.col_TraiteWasUpdated = true;
				this.col_TraiteWasSet = true;
				this.col_Traite = value;
			}
		}

		internal bool col_MethodeWasSet = false;
		private bool col_MethodeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Methode = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Methode {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Methode);
			}
			set {
			
				this.col_MethodeWasUpdated = true;
				this.col_MethodeWasSet = true;
				this.col_Methode = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_NomWasUpdated = false;
			this.col_NomWasSet = false;
			this.col_Nom = System.Data.SqlTypes.SqlString.Null;

			this.col_RepresentantWasUpdated = false;
			this.col_RepresentantWasSet = false;
			this.col_Representant = System.Data.SqlTypes.SqlString.Null;

			this.col_ADRESSEWasUpdated = false;
			this.col_ADRESSEWasSet = false;
			this.col_ADRESSE = System.Data.SqlTypes.SqlString.Null;

			this.col_VilleWasUpdated = false;
			this.col_VilleWasSet = false;
			this.col_Ville = System.Data.SqlTypes.SqlString.Null;

			this.col_CODE_POSTWasUpdated = false;
			this.col_CODE_POSTWasSet = false;
			this.col_CODE_POST = System.Data.SqlTypes.SqlString.Null;

			this.col_TEL_RESWasUpdated = false;
			this.col_TEL_RESWasSet = false;
			this.col_TEL_RES = System.Data.SqlTypes.SqlString.Null;

			this.col_TEL_BURWasUpdated = false;
			this.col_TEL_BURWasSet = false;
			this.col_TEL_BUR = System.Data.SqlTypes.SqlString.Null;

			this.col_FournisseurIDWasUpdated = false;
			this.col_FournisseurIDWasSet = false;
			this.col_FournisseurID = System.Data.SqlTypes.SqlString.Null;

			this.col_FournisseurNomWasUpdated = false;
			this.col_FournisseurNomWasSet = false;
			this.col_FournisseurNom = System.Data.SqlTypes.SqlString.Null;

			this.col_TraiteWasUpdated = false;
			this.col_TraiteWasSet = false;
			this.col_Traite = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_MethodeWasUpdated = false;
			this.col_MethodeWasSet = false;
			this.col_Methode = System.Data.SqlTypes.SqlString.Null;

			Params.spS_Cert_Proprietaire Param = new Params.spS_Cert_Proprietaire(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_Agence.IsNull) {

				Param.Param_Agence = this.col_Agence;
			}

			if (!this.col_NO_ACT.IsNull) {

				Param.Param_NO_ACT = this.col_NO_ACT;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Cert_Proprietaire Sp = new SPs.spS_Cert_Proprietaire();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Nom.ColumnIndex)) {

						this.col_Nom = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Nom.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Representant.ColumnIndex)) {

						this.col_Representant = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Representant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_ADRESSE.ColumnIndex)) {

						this.col_ADRESSE = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_ADRESSE.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Ville.ColumnIndex)) {

						this.col_Ville = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Ville.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_CODE_POST.ColumnIndex)) {

						this.col_CODE_POST = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_CODE_POST.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_TEL_RES.ColumnIndex)) {

						this.col_TEL_RES = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_TEL_RES.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_TEL_BUR.ColumnIndex)) {

						this.col_TEL_BUR = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_TEL_BUR.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_FournisseurID.ColumnIndex)) {

						this.col_FournisseurID = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_FournisseurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_FournisseurNom.ColumnIndex)) {

						this.col_FournisseurNom = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_FournisseurNom.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Traite.ColumnIndex)) {

						this.col_Traite = sqlDataReader.GetSqlBoolean(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Traite.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Methode.ColumnIndex)) {

						this.col_Methode = sqlDataReader.GetSqlString(SPs.spS_Cert_Proprietaire.Resultset1.Fields.Column_Methode.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Cert_Proprietaire_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NomWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RepresentantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ADRESSEWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VilleWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CODE_POSTWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TEL_RESWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TEL_BURWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FournisseurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FournisseurNomWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TraiteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MethodeWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Cert_Proprietaire Param = new Params.spU_Cert_Proprietaire(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_Agence = this.col_Agence;
			Param.Param_NO_ACT = this.col_NO_ACT;

			if (this.col_NomWasUpdated) {

				Param.Param_Nom = this.col_Nom;
				Param.Param_ConsiderNull_Nom = true;
			}

			if (this.col_RepresentantWasUpdated) {

				Param.Param_Representant = this.col_Representant;
				Param.Param_ConsiderNull_Representant = true;
			}

			if (this.col_ADRESSEWasUpdated) {

				Param.Param_ADRESSE = this.col_ADRESSE;
				Param.Param_ConsiderNull_ADRESSE = true;
			}

			if (this.col_VilleWasUpdated) {

				Param.Param_Ville = this.col_Ville;
				Param.Param_ConsiderNull_Ville = true;
			}

			if (this.col_CODE_POSTWasUpdated) {

				Param.Param_CODE_POST = this.col_CODE_POST;
				Param.Param_ConsiderNull_CODE_POST = true;
			}

			if (this.col_TEL_RESWasUpdated) {

				Param.Param_TEL_RES = this.col_TEL_RES;
				Param.Param_ConsiderNull_TEL_RES = true;
			}

			if (this.col_TEL_BURWasUpdated) {

				Param.Param_TEL_BUR = this.col_TEL_BUR;
				Param.Param_ConsiderNull_TEL_BUR = true;
			}

			if (this.col_FournisseurIDWasUpdated) {

				Param.Param_FournisseurID = this.col_FournisseurID;
				Param.Param_ConsiderNull_FournisseurID = true;
			}

			if (this.col_FournisseurNomWasUpdated) {

				Param.Param_FournisseurNom = this.col_FournisseurNom;
				Param.Param_ConsiderNull_FournisseurNom = true;
			}

			if (this.col_TraiteWasUpdated) {

				Param.Param_Traite = this.col_Traite;
				Param.Param_ConsiderNull_Traite = true;
			}

			if (this.col_MethodeWasUpdated) {

				Param.Param_Methode = this.col_Methode;
				Param.Param_ConsiderNull_Methode = true;
			}

			SPs.spU_Cert_Proprietaire Sp = new SPs.spU_Cert_Proprietaire();
			if (Sp.Execute(ref Param)) {

				this.col_NomWasUpdated = false;
				this.col_RepresentantWasUpdated = false;
				this.col_ADRESSEWasUpdated = false;
				this.col_VilleWasUpdated = false;
				this.col_CODE_POSTWasUpdated = false;
				this.col_TEL_RESWasUpdated = false;
				this.col_TEL_BURWasUpdated = false;
				this.col_FournisseurIDWasUpdated = false;
				this.col_FournisseurNomWasUpdated = false;
				this.col_TraiteWasUpdated = false;
				this.col_MethodeWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Cert_Proprietaire_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Cert_Proprietaire_Display Param = new Params.spS_Cert_Proprietaire_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_Agence = this.col_Agence;
				Param.Param_NO_ACT = this.col_NO_ACT;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Cert_Proprietaire_Display Sp = new SPs.spS_Cert_Proprietaire_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Cert_Proprietaire_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Cert_Proprietaire_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Cert_Proprietaire_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
