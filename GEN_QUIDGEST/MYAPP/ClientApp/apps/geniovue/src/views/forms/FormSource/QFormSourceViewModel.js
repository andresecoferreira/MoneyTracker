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
			name: 'SOURCE',
			area: 'SOURCE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Source',
				updateFilesTickets: 'UpdateFilesTicketsSource',
				setFile: 'SetFileSource'
			}
		})

		/** The primary key. */
		this.ValCodsource = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodsource',
			originId: 'ValCodsource',
			area: 'SOURCE',
			field: 'CODSOURCE',
			description: '',
		}).cloneFrom(values?.ValCodsource))
		this.stopWatchers.push(watch(() => this.ValCodsource.value, (newValue, oldValue) => this.onUpdate('source.codsource', this.ValCodsource, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValGroup_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValGroup_id',
			originId: 'ValGroup_id',
			area: 'SOURCE',
			field: 'GROUP_ID',
			relatedArea: 'GROUP',
			isFixed: true,
			description: computed(() => this.Resources.GROUP38232),
		}).cloneFrom(values?.ValGroup_id))
		this.stopWatchers.push(watch(() => this.ValGroup_id.value, (newValue, oldValue) => this.onUpdate('source.group_id', this.ValGroup_id, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValMember_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValMember_id',
			originId: 'ValMember_id',
			area: 'SOURCE',
			field: 'MEMBER_ID',
			relatedArea: 'MEMBER',
			description: computed(() => this.Resources.MEMBER00534),
		}).cloneFrom(values?.ValMember_id))
		this.stopWatchers.push(watch(() => this.ValMember_id.value, (newValue, oldValue) => this.onUpdate('source.member_id', this.ValMember_id, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValType = reactive(new modelFieldType.String({
			id: 'ValType',
			originId: 'ValType',
			area: 'SOURCE',
			field: 'TYPE',
			maxLength: 2,
			valueFormula: {
				stopRecalcCondition() { return false },
				execCondition() { return qApi.emptyC(this.ValType.value) },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: "CA"
					return "CA"
				},
				dependencyEvents: [],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			arrayOptions: computed(() => new qProjArrays.QArrayAccout_type(vm.$getResource).elements),
			description: computed(() => this.Resources.TYPE00312),
		}).cloneFrom(values?.ValType))
		this.stopWatchers.push(watch(() => this.ValType.value, (newValue, oldValue) => this.onUpdate('source.type', this.ValType, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'SOURCE',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('source.title', this.ValTitle, newValue, oldValue)))

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

		this.ValBank = reactive(new modelFieldType.String({
			id: 'ValBank',
			originId: 'ValBank',
			area: 'SOURCE',
			field: 'BANK',
			maxLength: 12,
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [SOURCE-> TYPE] != "CA"
					return this.ValType.value!=="CA"
				},
				dependencyEvents: ['fieldChange:source.type'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			arrayOptions: computed(() => new qProjArrays.QArrayBanks(vm.$getResource).elements),
			description: computed(() => this.Resources.BANK26563),
		}).cloneFrom(values?.ValBank))
		this.stopWatchers.push(watch(() => this.ValBank.value, (newValue, oldValue) => this.onUpdate('source.bank', this.ValBank, newValue, oldValue)))

		this.ValAccount_number = reactive(new modelFieldType.String({
			id: 'ValAccount_number',
			originId: 'ValAccount_number',
			area: 'SOURCE',
			field: 'ACCOUNT_NUMBER',
			maxLength: 20,
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [SOURCE-> TYPE] != "CA"
					return this.ValType.value!=="CA"
				},
				dependencyEvents: ['fieldChange:source.type'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.ACCOUNT_NUMBER58504),
		}).cloneFrom(values?.ValAccount_number))
		this.stopWatchers.push(watch(() => this.ValAccount_number.value, (newValue, oldValue) => this.onUpdate('source.account_number', this.ValAccount_number, newValue, oldValue)))

		this.ValBalance = reactive(new modelFieldType.Number({
			id: 'ValBalance',
			originId: 'ValBalance',
			area: 'SOURCE',
			field: 'BALANCE',
			maxDigits: 10,
			decimalDigits: 4,
			description: computed(() => this.Resources.BALANCE13297),
		}).cloneFrom(values?.ValBalance))
		this.stopWatchers.push(watch(() => this.ValBalance.value, (newValue, oldValue) => this.onUpdate('source.balance', this.ValBalance, newValue, oldValue)))

		this.ValCreated_at = reactive(new modelFieldType.Date({
			id: 'ValCreated_at',
			originId: 'ValCreated_at',
			area: 'SOURCE',
			field: 'CREATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.CREATED_AT09073),
		}).cloneFrom(values?.ValCreated_at))
		this.stopWatchers.push(watch(() => this.ValCreated_at.value, (newValue, oldValue) => this.onUpdate('source.created_at', this.ValCreated_at, newValue, oldValue)))

		this.ValCreated_by = reactive(new modelFieldType.String({
			id: 'ValCreated_by',
			originId: 'ValCreated_by',
			area: 'SOURCE',
			field: 'CREATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.CREATED_BY58035),
		}).cloneFrom(values?.ValCreated_by))
		this.stopWatchers.push(watch(() => this.ValCreated_by.value, (newValue, oldValue) => this.onUpdate('source.created_by', this.ValCreated_by, newValue, oldValue)))

		this.ValUpdated_at = reactive(new modelFieldType.Date({
			id: 'ValUpdated_at',
			originId: 'ValUpdated_at',
			area: 'SOURCE',
			field: 'UPDATED_AT',
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_AT48366),
		}).cloneFrom(values?.ValUpdated_at))
		this.stopWatchers.push(watch(() => this.ValUpdated_at.value, (newValue, oldValue) => this.onUpdate('source.updated_at', this.ValUpdated_at, newValue, oldValue)))

		this.ValUpdated_by = reactive(new modelFieldType.String({
			id: 'ValUpdated_by',
			originId: 'ValUpdated_by',
			area: 'SOURCE',
			field: 'UPDATED_BY',
			maxLength: 100,
			isFixed: true,
			description: computed(() => this.Resources.UPDATED_BY38656),
		}).cloneFrom(values?.ValUpdated_by))
		this.stopWatchers.push(watch(() => this.ValUpdated_by.value, (newValue, oldValue) => this.onUpdate('source.updated_by', this.ValUpdated_by, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormSourceViewModel instance.
	 * @returns {QFormSourceViewModel} A new instance of QFormSourceViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodsource'

	get QPrimaryKey() { return this.ValCodsource.value }
	set QPrimaryKey(value) { this.ValCodsource.updateValue(value) }
}
