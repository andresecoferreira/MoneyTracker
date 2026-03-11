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
			name: 'CATEGORY_TYPE',
			area: 'CATEGORY_TYPE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Category_type',
				updateFilesTickets: 'UpdateFilesTicketsCategory_type',
				setFile: 'SetFileCategory_type'
			}
		})

		/** The primary key. */
		this.ValCodcategory_type = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcategory_type',
			originId: 'ValCodcategory_type',
			area: 'CATEGORY_TYPE',
			field: 'CODCATEGORY_TYPE',
			description: '',
		}).cloneFrom(values?.ValCodcategory_type))
		this.stopWatchers.push(watch(() => this.ValCodcategory_type.value, (newValue, oldValue) => this.onUpdate('category_type.codcategory_type', this.ValCodcategory_type, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValLogo = reactive(new modelFieldType.Image({
			id: 'ValLogo',
			originId: 'ValLogo',
			area: 'CATEGORY_TYPE',
			field: 'LOGO',
			description: computed(() => this.Resources.LOGO62483),
		}).cloneFrom(values?.ValLogo))
		this.stopWatchers.push(watch(() => this.ValLogo.value, (newValue, oldValue) => this.onUpdate('category_type.logo', this.ValLogo, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'CATEGORY_TYPE',
			field: 'NAME',
			maxLength: 20,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('category_type.name', this.ValName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormCategoryTypeViewModel instance.
	 * @returns {QFormCategoryTypeViewModel} A new instance of QFormCategoryTypeViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcategory_type'

	get QPrimaryKey() { return this.ValCodcategory_type.value }
	set QPrimaryKey(value) { this.ValCodcategory_type.updateValue(value) }
}
