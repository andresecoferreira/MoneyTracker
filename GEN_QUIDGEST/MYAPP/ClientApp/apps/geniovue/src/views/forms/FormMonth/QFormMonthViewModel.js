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
			name: 'MONTH',
			area: 'MONTH',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Month',
				updateFilesTickets: 'UpdateFilesTicketsMonth',
				setFile: 'SetFileMonth'
			}
		})

		/** The primary key. */
		this.ValCodmonth = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmonth',
			originId: 'ValCodmonth',
			area: 'MONTH',
			field: 'CODMONTH',
			description: '',
		}).cloneFrom(values?.ValCodmonth))
		this.stopWatchers.push(watch(() => this.ValCodmonth.value, (newValue, oldValue) => this.onUpdate('month.codmonth', this.ValCodmonth, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValYear_number = reactive(new modelFieldType.ForeignKey({
			id: 'ValYear_number',
			originId: 'ValYear_number',
			area: 'MONTH',
			field: 'YEAR_NUMBER',
			relatedArea: 'YEAR',
			description: computed(() => this.Resources.YEAR61794),
		}).cloneFrom(values?.ValYear_number))
		this.stopWatchers.push(watch(() => this.ValYear_number.value, (newValue, oldValue) => this.onUpdate('month.year_number', this.ValYear_number, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValMonth_number = reactive(new modelFieldType.Number({
			id: 'ValMonth_number',
			originId: 'ValMonth_number',
			area: 'MONTH',
			field: 'MONTH_NUMBER',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.MONTH_NUMBER33019),
		}).cloneFrom(values?.ValMonth_number))
		this.stopWatchers.push(watch(() => this.ValMonth_number.value, (newValue, oldValue) => this.onUpdate('month.month_number', this.ValMonth_number, newValue, oldValue)))

		this.ValMonth_title = reactive(new modelFieldType.String({
			id: 'ValMonth_title',
			originId: 'ValMonth_title',
			area: 'MONTH',
			field: 'MONTH_TITLE',
			maxLength: 15,
			description: computed(() => this.Resources.MONTH_TEXT33954),
		}).cloneFrom(values?.ValMonth_title))
		this.stopWatchers.push(watch(() => this.ValMonth_title.value, (newValue, oldValue) => this.onUpdate('month.month_title', this.ValMonth_title, newValue, oldValue)))

		this.TableYearYear_number = reactive(new modelFieldType.Number({
			type: 'Lookup',
			id: 'TableYearYear_number',
			originId: 'ValYear_number',
			area: 'YEAR',
			field: 'YEAR_NUMBER',
			maxDigits: 5,
			decimalDigits: 0,
			description: computed(() => this.Resources.YEAR61794),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableYearYear_number))
		this.stopWatchers.push(watch(() => this.TableYearYear_number.value, (newValue, oldValue) => this.onUpdate('year.year_number', this.TableYearYear_number, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormMonthViewModel instance.
	 * @returns {QFormMonthViewModel} A new instance of QFormMonthViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmonth'

	get QPrimaryKey() { return this.ValCodmonth.value }
	set QPrimaryKey(value) { this.ValCodmonth.updateValue(value) }
}
