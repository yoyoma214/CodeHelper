namespace CodeHelper.DataBaseHelper
{
    partial class SqlEditFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlEditFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnGenOrderBy = new System.Windows.Forms.Button();
            this.btnGenCCFlowService = new System.Windows.Forms.Button();
            this.btnGenActions = new System.Windows.Forms.Button();
            this.btnGenPageViewModel = new System.Windows.Forms.Button();
            this.btnGenDTOtoViewModel = new System.Windows.Forms.Button();
            this.btnGenViewModel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGenViewCondition = new System.Windows.Forms.Button();
            this.btnDTOtoResult = new System.Windows.Forms.Button();
            this.btnGenResultToDTO = new System.Windows.Forms.Button();
            this.btnGenResultDTO = new System.Windows.Forms.Button();
            this.btnGenResultModel = new System.Windows.Forms.Button();
            this.txtResultModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEncloseCondition = new System.Windows.Forms.CheckBox();
            this.btnValidateSql = new System.Windows.Forms.Button();
            this.btnGenService = new System.Windows.Forms.Button();
            this.btnGenVModelSearchCode = new System.Windows.Forms.Button();
            this.btnGenView = new System.Windows.Forms.Button();
            this.btntConvertCondtionDomainToDto = new System.Windows.Forms.Button();
            this.btnConvertCondtionDtoToDomain = new System.Windows.Forms.Button();
            this.btnGenSearchConditionDto = new System.Windows.Forms.Button();
            this.btnGenEFFunction = new System.Windows.Forms.Button();
            this.btnGenSqlFunction = new System.Windows.Forms.Button();
            this.btnGenSearchConditionInfo = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.textEditorControl = new ICSharpCode.TextEditor.TextEditorControl();
            this.textEditorControl_Output = new ICSharpCode.TextEditor.TextEditorControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名字";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 12);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 21);
            this.txtName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(334, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(415, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "撤销";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnGenOrderBy);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenCCFlowService);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenActions);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenPageViewModel);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenDTOtoViewModel);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenViewModel);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenViewCondition);
            this.splitContainer1.Panel1.Controls.Add(this.btnDTOtoResult);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenResultToDTO);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenResultDTO);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenResultModel);
            this.splitContainer1.Panel1.Controls.Add(this.txtResultModel);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cbEncloseCondition);
            this.splitContainer1.Panel1.Controls.Add(this.btnValidateSql);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenService);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenVModelSearchCode);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenView);
            this.splitContainer1.Panel1.Controls.Add(this.btntConvertCondtionDomainToDto);
            this.splitContainer1.Panel1.Controls.Add(this.btnConvertCondtionDtoToDomain);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenSearchConditionDto);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenEFFunction);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenSqlFunction);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenSearchConditionInfo);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(835, 596);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 11;
            // 
            // btnGenOrderBy
            // 
            this.btnGenOrderBy.Location = new System.Drawing.Point(685, 41);
            this.btnGenOrderBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenOrderBy.Name = "btnGenOrderBy";
            this.btnGenOrderBy.Size = new System.Drawing.Size(88, 23);
            this.btnGenOrderBy.TabIndex = 38;
            this.btnGenOrderBy.Text = "生成排序配置";
            this.btnGenOrderBy.UseVisualStyleBackColor = true;
            this.btnGenOrderBy.Click += new System.EventHandler(this.btnGenOrderBy_Click);
            // 
            // btnGenCCFlowService
            // 
            this.btnGenCCFlowService.Location = new System.Drawing.Point(740, 68);
            this.btnGenCCFlowService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenCCFlowService.Name = "btnGenCCFlowService";
            this.btnGenCCFlowService.Size = new System.Drawing.Size(83, 22);
            this.btnGenCCFlowService.TabIndex = 37;
            this.btnGenCCFlowService.Text = "CCFlow服务";
            this.btnGenCCFlowService.UseVisualStyleBackColor = true;
            this.btnGenCCFlowService.Click += new System.EventHandler(this.btnGenCCFlowService_Click);
            // 
            // btnGenActions
            // 
            this.btnGenActions.Location = new System.Drawing.Point(665, 96);
            this.btnGenActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenActions.Name = "btnGenActions";
            this.btnGenActions.Size = new System.Drawing.Size(75, 22);
            this.btnGenActions.TabIndex = 36;
            this.btnGenActions.Text = "生成Action";
            this.btnGenActions.UseVisualStyleBackColor = true;
            this.btnGenActions.Click += new System.EventHandler(this.btnGenActions_Click);
            // 
            // btnGenPageViewModel
            // 
            this.btnGenPageViewModel.Location = new System.Drawing.Point(489, 97);
            this.btnGenPageViewModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenPageViewModel.Name = "btnGenPageViewModel";
            this.btnGenPageViewModel.Size = new System.Drawing.Size(75, 22);
            this.btnGenPageViewModel.TabIndex = 35;
            this.btnGenPageViewModel.Text = "ViewModel";
            this.btnGenPageViewModel.UseVisualStyleBackColor = true;
            this.btnGenPageViewModel.Click += new System.EventHandler(this.btnGenPageViewModel_Click);
            // 
            // btnGenDTOtoViewModel
            // 
            this.btnGenDTOtoViewModel.Location = new System.Drawing.Point(343, 96);
            this.btnGenDTOtoViewModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenDTOtoViewModel.Name = "btnGenDTOtoViewModel";
            this.btnGenDTOtoViewModel.Size = new System.Drawing.Size(140, 23);
            this.btnGenDTOtoViewModel.TabIndex = 34;
            this.btnGenDTOtoViewModel.Text = "DTO转View结果类";
            this.btnGenDTOtoViewModel.UseVisualStyleBackColor = true;
            this.btnGenDTOtoViewModel.Click += new System.EventHandler(this.btnGenDTOtoViewModel_Click);
            // 
            // btnGenViewModel
            // 
            this.btnGenViewModel.Location = new System.Drawing.Point(249, 97);
            this.btnGenViewModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenViewModel.Name = "btnGenViewModel";
            this.btnGenViewModel.Size = new System.Drawing.Size(88, 23);
            this.btnGenViewModel.TabIndex = 33;
            this.btnGenViewModel.Text = "View结果类";
            this.btnGenViewModel.UseVisualStyleBackColor = true;
            this.btnGenViewModel.Click += new System.EventHandler(this.btnGenViewModel_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(124, 97);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "View条件转DTO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGenViewCondition
            // 
            this.btnGenViewCondition.Enabled = false;
            this.btnGenViewCondition.Location = new System.Drawing.Point(25, 97);
            this.btnGenViewCondition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenViewCondition.Name = "btnGenViewCondition";
            this.btnGenViewCondition.Size = new System.Drawing.Size(88, 23);
            this.btnGenViewCondition.TabIndex = 31;
            this.btnGenViewCondition.Text = "View查询条件";
            this.btnGenViewCondition.UseVisualStyleBackColor = true;
            this.btnGenViewCondition.Click += new System.EventHandler(this.btnGenViewCondition_Click);
            // 
            // btnDTOtoResult
            // 
            this.btnDTOtoResult.Location = new System.Drawing.Point(591, 41);
            this.btnDTOtoResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDTOtoResult.Name = "btnDTOtoResult";
            this.btnDTOtoResult.Size = new System.Drawing.Size(88, 23);
            this.btnDTOtoResult.TabIndex = 30;
            this.btnDTOtoResult.Text = "DTO转结果类";
            this.btnDTOtoResult.UseVisualStyleBackColor = true;
            this.btnDTOtoResult.Click += new System.EventHandler(this.btnDTOtoResult_Click);
            // 
            // btnGenResultToDTO
            // 
            this.btnGenResultToDTO.Location = new System.Drawing.Point(496, 41);
            this.btnGenResultToDTO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenResultToDTO.Name = "btnGenResultToDTO";
            this.btnGenResultToDTO.Size = new System.Drawing.Size(88, 23);
            this.btnGenResultToDTO.TabIndex = 29;
            this.btnGenResultToDTO.Text = "结果类转DTO";
            this.btnGenResultToDTO.UseVisualStyleBackColor = true;
            this.btnGenResultToDTO.Click += new System.EventHandler(this.btnGenResultToDTO_Click);
            // 
            // btnGenResultDTO
            // 
            this.btnGenResultDTO.Location = new System.Drawing.Point(415, 41);
            this.btnGenResultDTO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenResultDTO.Name = "btnGenResultDTO";
            this.btnGenResultDTO.Size = new System.Drawing.Size(75, 23);
            this.btnGenResultDTO.TabIndex = 28;
            this.btnGenResultDTO.Text = "结果类DTO";
            this.btnGenResultDTO.UseVisualStyleBackColor = true;
            this.btnGenResultDTO.Click += new System.EventHandler(this.btnGenResultDTO_Click);
            // 
            // btnGenResultModel
            // 
            this.btnGenResultModel.Location = new System.Drawing.Point(335, 41);
            this.btnGenResultModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenResultModel.Name = "btnGenResultModel";
            this.btnGenResultModel.Size = new System.Drawing.Size(74, 23);
            this.btnGenResultModel.TabIndex = 27;
            this.btnGenResultModel.Text = "结果类";
            this.btnGenResultModel.UseVisualStyleBackColor = true;
            this.btnGenResultModel.Click += new System.EventHandler(this.btnGenResultModel_Click);
            // 
            // txtResultModel
            // 
            this.txtResultModel.Location = new System.Drawing.Point(168, 41);
            this.txtResultModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtResultModel.Name = "txtResultModel";
            this.txtResultModel.Size = new System.Drawing.Size(161, 21);
            this.txtResultModel.TabIndex = 26;
            this.txtResultModel.TextChanged += new System.EventHandler(this.txtResultModel_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "结果类名字：";
            // 
            // cbEncloseCondition
            // 
            this.cbEncloseCondition.AutoSize = true;
            this.cbEncloseCondition.Location = new System.Drawing.Point(25, 43);
            this.cbEncloseCondition.Margin = new System.Windows.Forms.Padding(2);
            this.cbEncloseCondition.Name = "cbEncloseCondition";
            this.cbEncloseCondition.Size = new System.Drawing.Size(72, 16);
            this.cbEncloseCondition.TabIndex = 24;
            this.cbEncloseCondition.Text = "封装条件";
            this.cbEncloseCondition.UseVisualStyleBackColor = true;
            this.cbEncloseCondition.CheckedChanged += new System.EventHandler(this.cbEncloseCondition_CheckedChanged);
            // 
            // btnValidateSql
            // 
            this.btnValidateSql.Location = new System.Drawing.Point(496, 10);
            this.btnValidateSql.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValidateSql.Name = "btnValidateSql";
            this.btnValidateSql.Size = new System.Drawing.Size(75, 23);
            this.btnValidateSql.TabIndex = 23;
            this.btnValidateSql.Text = "验证SQL";
            this.btnValidateSql.UseVisualStyleBackColor = true;
            this.btnValidateSql.Click += new System.EventHandler(this.btnValidateSql_Click);
            // 
            // btnGenService
            // 
            this.btnGenService.Location = new System.Drawing.Point(652, 68);
            this.btnGenService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenService.Name = "btnGenService";
            this.btnGenService.Size = new System.Drawing.Size(83, 22);
            this.btnGenService.TabIndex = 22;
            this.btnGenService.Text = "生成Serivce";
            this.btnGenService.UseVisualStyleBackColor = true;
            this.btnGenService.Click += new System.EventHandler(this.btnGenService_Click);
            // 
            // btnGenVModelSearchCode
            // 
            this.btnGenVModelSearchCode.Location = new System.Drawing.Point(570, 96);
            this.btnGenVModelSearchCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenVModelSearchCode.Name = "btnGenVModelSearchCode";
            this.btnGenVModelSearchCode.Size = new System.Drawing.Size(89, 22);
            this.btnGenVModelSearchCode.TabIndex = 20;
            this.btnGenVModelSearchCode.Text = "View查询代码";
            this.btnGenVModelSearchCode.UseVisualStyleBackColor = true;
            this.btnGenVModelSearchCode.Click += new System.EventHandler(this.btnGenVModelSearchCode_Click);
            // 
            // btnGenView
            // 
            this.btnGenView.Location = new System.Drawing.Point(748, 96);
            this.btnGenView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenView.Name = "btnGenView";
            this.btnGenView.Size = new System.Drawing.Size(75, 22);
            this.btnGenView.TabIndex = 19;
            this.btnGenView.Text = "生成视图";
            this.btnGenView.UseVisualStyleBackColor = true;
            this.btnGenView.Click += new System.EventHandler(this.btnGenView_Click);
            // 
            // btntConvertCondtionDomainToDto
            // 
            this.btntConvertCondtionDomainToDto.Location = new System.Drawing.Point(395, 70);
            this.btntConvertCondtionDomainToDto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntConvertCondtionDomainToDto.Name = "btntConvertCondtionDomainToDto";
            this.btntConvertCondtionDomainToDto.Size = new System.Drawing.Size(140, 23);
            this.btntConvertCondtionDomainToDto.TabIndex = 18;
            this.btntConvertCondtionDomainToDto.Text = "查询条件Domain转DTO";
            this.btntConvertCondtionDomainToDto.UseVisualStyleBackColor = true;
            this.btntConvertCondtionDomainToDto.Click += new System.EventHandler(this.btntConvertConditionDomainToDto_Click);
            // 
            // btnConvertCondtionDtoToDomain
            // 
            this.btnConvertCondtionDtoToDomain.Location = new System.Drawing.Point(249, 70);
            this.btnConvertCondtionDtoToDomain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConvertCondtionDtoToDomain.Name = "btnConvertCondtionDtoToDomain";
            this.btnConvertCondtionDtoToDomain.Size = new System.Drawing.Size(135, 23);
            this.btnConvertCondtionDtoToDomain.TabIndex = 17;
            this.btnConvertCondtionDtoToDomain.Text = "查询条件DTO转Domain";
            this.btnConvertCondtionDtoToDomain.UseVisualStyleBackColor = true;
            this.btnConvertCondtionDtoToDomain.Click += new System.EventHandler(this.btnConvertConditionDtoToDomain_Click);
            // 
            // btnGenSearchConditionDto
            // 
            this.btnGenSearchConditionDto.Location = new System.Drawing.Point(124, 70);
            this.btnGenSearchConditionDto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenSearchConditionDto.Name = "btnGenSearchConditionDto";
            this.btnGenSearchConditionDto.Size = new System.Drawing.Size(114, 23);
            this.btnGenSearchConditionDto.TabIndex = 16;
            this.btnGenSearchConditionDto.Text = "生成查询条件DTO";
            this.btnGenSearchConditionDto.UseVisualStyleBackColor = true;
            this.btnGenSearchConditionDto.Click += new System.EventHandler(this.btnGenSearchConditionDto_Click);
            // 
            // btnGenEFFunction
            // 
            this.btnGenEFFunction.Location = new System.Drawing.Point(546, 67);
            this.btnGenEFFunction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenEFFunction.Name = "btnGenEFFunction";
            this.btnGenEFFunction.Size = new System.Drawing.Size(100, 23);
            this.btnGenEFFunction.TabIndex = 15;
            this.btnGenEFFunction.Text = "生成EF查询方法";
            this.btnGenEFFunction.UseVisualStyleBackColor = true;
            this.btnGenEFFunction.Click += new System.EventHandler(this.btnGenEFFunction_Click);
            // 
            // btnGenSqlFunction
            // 
            this.btnGenSqlFunction.Enabled = false;
            this.btnGenSqlFunction.Location = new System.Drawing.Point(591, 9);
            this.btnGenSqlFunction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenSqlFunction.Name = "btnGenSqlFunction";
            this.btnGenSqlFunction.Size = new System.Drawing.Size(110, 23);
            this.btnGenSqlFunction.TabIndex = 14;
            this.btnGenSqlFunction.Text = "生成SQL查询方法";
            this.btnGenSqlFunction.UseVisualStyleBackColor = true;
            this.btnGenSqlFunction.Click += new System.EventHandler(this.btnGenSqlFunction_Click);
            // 
            // btnGenSearchConditionInfo
            // 
            this.btnGenSearchConditionInfo.Location = new System.Drawing.Point(25, 70);
            this.btnGenSearchConditionInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenSearchConditionInfo.Name = "btnGenSearchConditionInfo";
            this.btnGenSearchConditionInfo.Size = new System.Drawing.Size(88, 23);
            this.btnGenSearchConditionInfo.TabIndex = 12;
            this.btnGenSearchConditionInfo.Text = "生成查询条件";
            this.btnGenSearchConditionInfo.UseVisualStyleBackColor = true;
            this.btnGenSearchConditionInfo.Click += new System.EventHandler(this.btnGenSearchConditionInfo_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(253, 10);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 11;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(835, 457);
            this.splitContainer2.SplitterDistance = 369;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.textEditorControl);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.textEditorControl_Output);
            this.splitContainer3.Size = new System.Drawing.Size(835, 369);
            this.splitContainer3.SplitterDistance = 208;
            this.splitContainer3.TabIndex = 2;
            // 
            // textEditorControl
            // 
            this.textEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl.IsReadOnly = false;
            this.textEditorControl.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEditorControl.Name = "textEditorControl";
            this.textEditorControl.Size = new System.Drawing.Size(835, 208);
            this.textEditorControl.TabIndex = 0;
            // 
            // textEditorControl_Output
            // 
            this.textEditorControl_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl_Output.IsReadOnly = false;
            this.textEditorControl_Output.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl_Output.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEditorControl_Output.Name = "textEditorControl_Output";
            this.textEditorControl_Output.Size = new System.Drawing.Size(835, 157);
            this.textEditorControl_Output.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(835, 84);
            this.dataGridView1.TabIndex = 0;
            // 
            // SqlEditFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 596);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SqlEditFrm";
            this.Text = "查询语句";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnQuery;
        //private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSql;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSql;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl;
        private System.Windows.Forms.Button btnGenEFFunction;
        private System.Windows.Forms.Button btnGenSqlFunction;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl_Output;
        private System.Windows.Forms.Button btnGenSearchConditionDto;
        private System.Windows.Forms.Button btnConvertCondtionDtoToDomain;
        private System.Windows.Forms.Button btntConvertCondtionDomainToDto;
        private System.Windows.Forms.Button btnGenView;
        private System.Windows.Forms.Button btnGenVModelSearchCode;
        private System.Windows.Forms.Button btnGenService;
        private System.Windows.Forms.Button btnValidateSql;
        private System.Windows.Forms.CheckBox cbEncloseCondition;
        private System.Windows.Forms.TextBox txtResultModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenResultToDTO;
        private System.Windows.Forms.Button btnGenResultDTO;
        private System.Windows.Forms.Button btnGenResultModel;
        private System.Windows.Forms.Button btnGenSearchConditionInfo;
        private System.Windows.Forms.Button btnDTOtoResult;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnGenDTOtoViewModel;
        private System.Windows.Forms.Button btnGenViewModel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGenViewCondition;
        private System.Windows.Forms.Button btnGenPageViewModel;
        private System.Windows.Forms.Button btnGenActions;
        private System.Windows.Forms.Button btnGenCCFlowService;
        private System.Windows.Forms.Button btnGenOrderBy;
    }
}