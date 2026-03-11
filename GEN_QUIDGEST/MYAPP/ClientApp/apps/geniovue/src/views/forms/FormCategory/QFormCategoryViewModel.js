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
			name: 'CATEGORY',
			area: 'CATEGORY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Category',
				updateFilesTickets: 'UpdateFilesTicketsCategory',
				setFile: 'SetFileCategory'
			}
		})

		/** The primary key. */
		this.ValCodcategory = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcategory',
			originId: 'ValCodcategory',
			area: 'CATEGORY',
			field: 'CODCATEGORY',
			description: '',
		}).cloneFrom(values?.ValCodcategory))
		this.stopWatchers.push(watch(() => this.ValCodcategory.value, (newValue, oldValue) => this.onUpdate('category.codcategory', this.ValCodcategory, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValType_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValType_id',
			originId: 'ValType_id',
			area: 'CATEGORY',
			field: 'TYPE_ID',
			relatedArea: 'CATEGORY_TYPE',
			description: computed(() => this.Resources.TYPE00312),
		}).cloneFrom(values?.ValType_id))
		this.stopWatchers.push(watch(() => this.ValType_id.value, (newValue, oldValue) => this.onUpdate('category.type_id', this.ValType_id, newValue, oldValue)))

		/** The remaining form fields. */
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

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'CATEGORY',
			field: 'NAME',
			maxLength: 20,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('category.name', this.ValName, newValue, oldValue)))

		this.ValDescription = reactive(new modelFieldType.String({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'CATEGORY',
			field: 'DESCRIPTION',
			maxLength: 80,
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('category.description', this.ValDescription, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormCategoryViewModel instance.
	 * @returns {QFormCategoryViewModel} A new instance of QFormCategoryViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcategory'

	get QPrimaryKey() { return this.ValCodcategory.value }
	set QPrimaryKey(value) { this.ValCodcategory.updateValue(value) }
}
