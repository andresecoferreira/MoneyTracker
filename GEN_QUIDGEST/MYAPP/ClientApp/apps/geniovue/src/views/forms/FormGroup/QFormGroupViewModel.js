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
			name: 'GROUP',
			area: 'GROUP',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Group',
				updateFilesTickets: 'UpdateFilesTicketsGroup',
				setFile: 'SetFileGroup'
			}
		})

		/** The primary key. */
		this.ValCodgroup = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodgroup',
			originId: 'ValCodgroup',
			area: 'GROUP',
			field: 'CODGROUP',
			description: '',
		}).cloneFrom(values?.ValCodgroup))
		this.stopWatchers.push(watch(() => this.ValCodgroup.value, (newValue, oldValue) => this.onUpdate('group.codgroup', this.ValCodgroup, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'GROUP',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('group.name', this.ValName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormGroupViewModel instance.
	 * @returns {QFormGroupViewModel} A new instance of QFormGroupViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodgroup'

	get QPrimaryKey() { return this.ValCodgroup.value }
	set QPrimaryKey(value) { this.ValCodgroup.updateValue(value) }
}
