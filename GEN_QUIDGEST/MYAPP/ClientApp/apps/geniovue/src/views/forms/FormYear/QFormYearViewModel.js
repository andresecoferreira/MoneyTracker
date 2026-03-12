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
			name: 'YEAR',
			area: 'YEAR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Year',
				updateFilesTickets: 'UpdateFilesTicketsYear',
				setFile: 'SetFileYear'
			}
		})

		/** The primary key. */
		this.ValCodyear = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodyear',
			originId: 'ValCodyear',
			area: 'YEAR',
			field: 'CODYEAR',
			description: '',
		}).cloneFrom(values?.ValCodyear))
		this.stopWatchers.push(watch(() => this.ValCodyear.value, (newValue, oldValue) => this.onUpdate('year.codyear', this.ValCodyear, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValYear_number = reactive(new modelFieldType.Number({
			id: 'ValYear_number',
			originId: 'ValYear_number',
			area: 'YEAR',
			field: 'YEAR_NUMBER',
			maxDigits: 5,
			decimalDigits: 0,
			description: computed(() => this.Resources.YEAR61794),
		}).cloneFrom(values?.ValYear_number))
		this.stopWatchers.push(watch(() => this.ValYear_number.value, (newValue, oldValue) => this.onUpdate('year.year_number', this.ValYear_number, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormYearViewModel instance.
	 * @returns {QFormYearViewModel} A new instance of QFormYearViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodyear'

	get QPrimaryKey() { return this.ValCodyear.value }
	set QPrimaryKey(value) { this.ValCodyear.updateValue(value) }
}
