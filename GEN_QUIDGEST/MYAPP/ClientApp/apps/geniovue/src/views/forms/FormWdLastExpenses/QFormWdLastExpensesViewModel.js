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
			name: 'WD_LAST_EXPENSES',
			area: 'EXPENSE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Wd_last_expenses',
				updateFilesTickets: 'UpdateFilesTicketsWd_last_expenses',
				setFile: 'SetFileWd_last_expenses'
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

		/** The hidden foreign keys. */
		this.ValMember_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValMember_id',
			originId: 'ValMember_id',
			area: 'EXPENSE',
			field: 'MEMBER_ID',
			relatedArea: 'MEMBER',
			isFixed: true,
			description: computed(() => this.Resources.MEMBER00534),
		}).cloneFrom(values?.ValMember_id))
		this.stopWatchers.push(watch(() => this.ValMember_id.value, (newValue, oldValue) => this.onUpdate('expense.member_id', this.ValMember_id, newValue, oldValue)))

		this.ValType_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValType_id',
			originId: 'ValType_id',
			area: 'EXPENSE',
			field: 'TYPE_ID',
			relatedArea: 'CATEGORY_TYPE',
			isFixed: true,
			description: computed(() => this.Resources.CATEGORY_TYPE34342),
		}).cloneFrom(values?.ValType_id))
		this.stopWatchers.push(watch(() => this.ValType_id.value, (newValue, oldValue) => this.onUpdate('expense.type_id', this.ValType_id, newValue, oldValue)))

		this.ValMonth_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValMonth_fk',
			originId: 'ValMonth_fk',
			area: 'EXPENSE',
			field: 'MONTH_FK',
			relatedArea: 'MONTH',
			isFixed: true,
			description: '',
		}).cloneFrom(values?.ValMonth_fk))
		this.stopWatchers.push(watch(() => this.ValMonth_fk.value, (newValue, oldValue) => this.onUpdate('expense.month_fk', this.ValMonth_fk, newValue, oldValue)))

		this.ValGroup_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValGroup_id',
			originId: 'ValGroup_id',
			area: 'EXPENSE',
			field: 'GROUP_ID',
			relatedArea: 'GROUP',
			isFixed: true,
			description: computed(() => this.Resources.GROUP38232),
		}).cloneFrom(values?.ValGroup_id))
		this.stopWatchers.push(watch(() => this.ValGroup_id.value, (newValue, oldValue) => this.onUpdate('expense.group_id', this.ValGroup_id, newValue, oldValue)))

		this.ValCategory_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValCategory_id',
			originId: 'ValCategory_id',
			area: 'EXPENSE',
			field: 'CATEGORY_ID',
			relatedArea: 'CATEGORY',
			isFixed: true,
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategory_id))
		this.stopWatchers.push(watch(() => this.ValCategory_id.value, (newValue, oldValue) => this.onUpdate('expense.category_id', this.ValCategory_id, newValue, oldValue)))

		this.ValSource_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValSource_id',
			originId: 'ValSource_id',
			area: 'EXPENSE',
			field: 'SOURCE_ID',
			relatedArea: 'SOURCE',
			isFixed: true,
			description: computed(() => this.Resources.ACCOUNT64260),
		}).cloneFrom(values?.ValSource_id))
		this.stopWatchers.push(watch(() => this.ValSource_id.value, (newValue, oldValue) => this.onUpdate('expense.source_id', this.ValSource_id, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.ValExpense_id = reactive(new modelFieldType.Number({
			id: 'ValExpense_id',
			originId: 'ValExpense_id',
			area: 'EXPENSE',
			field: 'EXPENSE_ID',
			maxDigits: 6,
			decimalDigits: 0,
			isFixed: true,
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

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'EXPENSE',
			field: 'DATE',
			isFixed: true,
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('expense.date', this.ValDate, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormWdLastExpensesViewModel instance.
	 * @returns {QFormWdLastExpensesViewModel} A new instance of QFormWdLastExpensesViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodexpense'

	get QPrimaryKey() { return this.ValCodexpense.value }
	set QPrimaryKey(value) { this.ValCodexpense.updateValue(value) }
}
