/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'EXPENSE',
			area: 'EXPENSE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Expense',
				updateFilesTickets: 'UpdateFilesTicketsExpense',
				setFile: 'SetFileExpense'
			}
		})

		/** The primary key. */
		this.ValCodexpense = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodexpense',
			originId: 'ValCodexpense',
			area: 'EXPENSE',
			field: 'CODEXPENSE',
			description: '',
		}).cloneFrom(values?.ValCodexpense))
		this.stopWatchers.push(watch(() => this.ValCodexpense.value, (newValue, oldValue) => this.onUpdate('expense.codexpense', this.ValCodexpense, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCategory_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValCategory_id',
			originId: 'ValCategory_id',
			area: 'EXPENSE',
			field: 'CATEGORY_ID',
			relatedArea: 'CATEGORY',
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategory_id))
		this.stopWatchers.push(watch(() => this.ValCategory_id.value, (newValue, oldValue) => this.onUpdate('expense.category_id', this.ValCategory_id, newValue, oldValue)))

		this.ValMember_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValMember_id',
			originId: 'ValMember_id',
			area: 'EXPENSE',
			field: 'MEMBER_ID',
			relatedArea: 'MEMBER',
			description: computed(() => this.Resources.MEMBER00534),
		}).cloneFrom(values?.ValMember_id))
		this.stopWatchers.push(watch(() => this.ValMember_id.value, (newValue, oldValue) => this.onUpdate('expense.member_id', this.ValMember_id, newValue, oldValue)))

		this.ValSource_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValSource_id',
			originId: 'ValSource_id',
			area: 'EXPENSE',
			field: 'SOURCE_ID',
			relatedArea: 'SOURCE',
			description: computed(() => this.Resources.ACCOUNT64260),
		}).cloneFrom(values?.ValSource_id))
		this.stopWatchers.push(watch(() => this.ValSource_id.value, (newValue, oldValue) => this.onUpdate('expense.source_id', this.ValSource_id, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValExpense_id = reactive(new modelFieldType.Number({
			id: 'ValExpense_id',
			originId: 'ValExpense_id',
			area: 'EXPENSE',
			field: 'EXPENSE_ID',
			maxDigits: 6,
			decimalDigits: 0,
			blockWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [True]
					return true
				},
				dependencyEvents: [],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.ID36840),
		}).cloneFrom(values?.ValExpense_id))
		this.stopWatchers.push(watch(() => this.ValExpense_id.value, (newValue, oldValue) => this.onUpdate('expense.expense_id', this.ValExpense_id, newValue, oldValue)))

		this.TableCategoryName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCategoryName',
			originId: 'ValName',
			area: 'CATEGORY',
			field: 'NAME',
			maxLength: 20,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCategoryName))
		this.stopWatchers.push(watch(() => this.TableCategoryName.value, (newValue, oldValue) => this.onUpdate('category.name', this.TableCategoryName, newValue, oldValue)))

		this.TableMemberName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableMemberName',
			originId: 'ValName',
			area: 'MEMBER',
			field: 'NAME',
			maxLength: 80,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableMemberName))
		this.stopWatchers.push(watch(() => this.TableMemberName.value, (newValue, oldValue) => this.onUpdate('member.name', this.TableMemberName, newValue, oldValue)))

		this.TableSourceTitle = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableSourceTitle',
			originId: 'ValTitle',
			area: 'SOURCE',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableSourceTitle))
		this.stopWatchers.push(watch(() => this.TableSourceTitle.value, (newValue, oldValue) => this.onUpdate('source.title', this.TableSourceTitle, newValue, oldValue)))

		this.ValValue = reactive(new modelFieldType.Number({
			id: 'ValValue',
			originId: 'ValValue',
			area: 'EXPENSE',
			field: 'VALUE',
			maxDigits: 12,
			decimalDigits: 0,
			description: computed(() => this.Resources.VALUE10285),
		}).cloneFrom(values?.ValValue))
		this.stopWatchers.push(watch(() => this.ValValue.value, (newValue, oldValue) => this.onUpdate('expense.value', this.ValValue, newValue, oldValue)))

		this.ValDescription = reactive(new modelFieldType.String({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'EXPENSE',
			field: 'DESCRIPTION',
			maxLength: 200,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('expense.description', this.ValDescription, newValue, oldValue)))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'EXPENSE',
			field: 'DATE',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('expense.date', this.ValDate, newValue, oldValue)))

		this.ValInvoice = reactive(new modelFieldType.Document({
			id: 'ValInvoice',
			originId: 'ValInvoice',
			area: 'EXPENSE',
			field: 'INVOICE',
			properties: computed(() => this.ValInvoicePropertiesVM),
			documentFK: computed(() => this.ValInvoicefk),
			currentDocument: computed(() => this.ValInvoiceData),
			description: computed(() => this.Resources.INVOICE63068),
		}).cloneFrom(values?.ValInvoice))
		this.stopWatchers.push(watch(() => this.ValInvoice.value, (newValue, oldValue) => this.onUpdate('expense.invoice', this.ValInvoice, newValue, oldValue)))

		this.ValInvoicePropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValInvoicePropertiesVM',
			area: 'EXPENSE',
			field: 'INVOICEDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValInvoicePropertiesVM))
		this.ValInvoicefk = reactive(new modelFieldType.String({
			id: 'ValInvoicefk',
			area: 'EXPENSE',
			field: 'INVOICEFK'
		}).cloneFrom(values?.ValInvoicefk))
		this.stopWatchers.push(watch(() => this.ValInvoicefk.value, (newValue, oldValue) => this.onUpdate('expense.invoicefk', this.ValInvoicefk, newValue, oldValue)))

		this.ValInvoiceData = reactive(new modelFieldType.DocumentData({
			id: 'ValInvoiceData',
			area: 'EXPENSE',
			field: 'INVOICEDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValInvoiceData))
		this.stopWatchers.push(watch(() => this.ValInvoiceData.value, (newValue, oldValue) => this.onUpdate('expense.invoicedata', this.ValInvoiceData, newValue, oldValue), { deep: true }))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'EXPENSE',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('expense.updated_at', this.ValUpdated_at, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'EXPENSE',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT09073),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('expense.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'EXPENSE',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY58035),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('expense.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'EXPENSE',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY38656),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('expense.updated_by', this.ValUpdated_by, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormExpenseViewModel instance.
	 * @returns {QFormExpenseViewModel} A new instance of QFormExpenseViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodexpense'

	get QPrimaryKey() { return this.ValCodexpense.value }
	set QPrimaryKey(value) { this.ValCodexpense.updateValue(value) }
}
