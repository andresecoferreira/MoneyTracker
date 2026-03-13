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
			name: 'INVESTMENT',
			area: 'INVESTMENT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Investment',
				updateFilesTickets: 'UpdateFilesTicketsInvestment',
				setFile: 'SetFileInvestment'
			}
		})

		/** The primary key. */
		this.ValCodinvestment = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodinvestment',
			originId: 'ValCodinvestment',
			area: 'INVESTMENT',
			field: 'CODINVESTMENT',
			description: '',
		}).cloneFrom(values?.ValCodinvestment))
		this.stopWatchers.push(watch(() => this.ValCodinvestment.value, (newValue, oldValue) => this.onUpdate('investment.codinvestment', this.ValCodinvestment, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValGroup_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValGroup_id',
			originId: 'ValGroup_id',
			area: 'INVESTMENT',
			field: 'GROUP_ID',
			relatedArea: 'GROUP',
			isFixed: true,
			description: computed(() => this.Resources.GROUP38232),
		}).cloneFrom(values?.ValGroup_id))
		this.stopWatchers.push(watch(() => this.ValGroup_id.value, (newValue, oldValue) => this.onUpdate('investment.group_id', this.ValGroup_id, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValType_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValType_id',
			originId: 'ValType_id',
			area: 'INVESTMENT',
			field: 'TYPE_ID',
			relatedArea: 'CATEGORY_TYPE',
			description: computed(() => this.Resources.CATEGORY_TYPE34342),
		}).cloneFrom(values?.ValType_id))
		this.stopWatchers.push(watch(() => this.ValType_id.value, (newValue, oldValue) => this.onUpdate('investment.type_id', this.ValType_id, newValue, oldValue)))

		this.ValCategory_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValCategory_id',
			originId: 'ValCategory_id',
			area: 'INVESTMENT',
			field: 'CATEGORY_ID',
			relatedArea: 'CATEGORY',
			description: computed(() => this.Resources.CATEGORY18978),
		}).cloneFrom(values?.ValCategory_id))
		this.stopWatchers.push(watch(() => this.ValCategory_id.value, (newValue, oldValue) => this.onUpdate('investment.category_id', this.ValCategory_id, newValue, oldValue)))

		this.ValMember_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValMember_id',
			originId: 'ValMember_id',
			area: 'INVESTMENT',
			field: 'MEMBER_ID',
			relatedArea: 'MEMBER',
			description: computed(() => this.Resources.MEMBER00534),
		}).cloneFrom(values?.ValMember_id))
		this.stopWatchers.push(watch(() => this.ValMember_id.value, (newValue, oldValue) => this.onUpdate('investment.member_id', this.ValMember_id, newValue, oldValue)))

		this.ValSource_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValSource_id',
			originId: 'ValSource_id',
			area: 'INVESTMENT',
			field: 'SOURCE_ID',
			relatedArea: 'SOURCE',
			description: computed(() => this.Resources.ACCOUNT64260),
		}).cloneFrom(values?.ValSource_id))
		this.stopWatchers.push(watch(() => this.ValSource_id.value, (newValue, oldValue) => this.onUpdate('investment.source_id', this.ValSource_id, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValInvestment_id = reactive(new modelFieldType.Number({
			id: 'ValInvestment_id',
			originId: 'ValInvestment_id',
			area: 'INVESTMENT',
			field: 'INVESTMENT_ID',
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
		}).cloneFrom(values?.ValInvestment_id))
		this.stopWatchers.push(watch(() => this.ValInvestment_id.value, (newValue, oldValue) => this.onUpdate('investment.investment_id', this.ValInvestment_id, newValue, oldValue)))

		this.TableCategory_typeName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCategory_typeName',
			originId: 'ValName',
			area: 'CATEGORY_TYPE',
			field: 'NAME',
			maxLength: 20,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCategory_typeName))
		this.stopWatchers.push(watch(() => this.TableCategory_typeName.value, (newValue, oldValue) => this.onUpdate('category_type.name', this.TableCategory_typeName, newValue, oldValue)))

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

		this.GroupValName = reactive(new modelFieldType.String({
			id: 'GroupValName',
			originId: 'ValName',
			area: 'GROUP',
			field: 'NAME',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.GroupValName))
		this.stopWatchers.push(watch(() => this.GroupValName.value, (newValue, oldValue) => this.onUpdate('group.name', this.GroupValName, newValue, oldValue)))

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
			area: 'INVESTMENT',
			field: 'VALUE',
			maxDigits: 9,
			decimalDigits: 2,
			description: computed(() => this.Resources.VALUE____56887),
		}).cloneFrom(values?.ValValue))
		this.stopWatchers.push(watch(() => this.ValValue.value, (newValue, oldValue) => this.onUpdate('investment.value', this.ValValue, newValue, oldValue)))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'INVESTMENT',
			field: 'DATE',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('investment.date', this.ValDate, newValue, oldValue)))

		this.ValDescription = reactive(new modelFieldType.String({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'INVESTMENT',
			field: 'DESCRIPTION',
			maxLength: 100,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('investment.description', this.ValDescription, newValue, oldValue)))

		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'INVESTMENT',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY58035),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('investment.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'INVESTMENT',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT09073),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('investment.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'INVESTMENT',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY38656),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('investment.updated_by', this.ValUpdated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'INVESTMENT',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('investment.updated_at', this.ValUpdated_at, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormInvestmentViewModel instance.
	 * @returns {QFormInvestmentViewModel} A new instance of QFormInvestmentViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodinvestment'

	get QPrimaryKey() { return this.ValCodinvestment.value }
	set QPrimaryKey(value) { this.ValCodinvestment.updateValue(value) }
}
