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
			name: 'GROUP_PSW',
			area: 'GROUP_PSW',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Group_psw',
				updateFilesTickets: 'UpdateFilesTicketsGroup_psw',
				setFile: 'SetFileGroup_psw'
			}
		})

		/** The primary key. */
		this.ValCodgroup_psw = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodgroup_psw',
			originId: 'ValCodgroup_psw',
			area: 'GROUP_PSW',
			field: 'CODGROUP_PSW',
			description: '',
		}).cloneFrom(values?.ValCodgroup_psw))
		this.stopWatchers.push(watch(() => this.ValCodgroup_psw.value, (newValue, oldValue) => this.onUpdate('group_psw.codgroup_psw', this.ValCodgroup_psw, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValGroup_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValGroup_id',
			originId: 'ValGroup_id',
			area: 'GROUP_PSW',
			field: 'GROUP_ID',
			relatedArea: 'GROUP',
			description: computed(() => this.Resources.GROUP38232),
		}).cloneFrom(values?.ValGroup_id))
		this.stopWatchers.push(watch(() => this.ValGroup_id.value, (newValue, oldValue) => this.onUpdate('group_psw.group_id', this.ValGroup_id, newValue, oldValue)))

		this.ValCodpsw = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpsw',
			originId: 'ValCodpsw',
			area: 'GROUP_PSW',
			field: 'CODPSW',
			relatedArea: 'PSW',
			description: computed(() => this.Resources.CODPSW13775),
		}).cloneFrom(values?.ValCodpsw))
		this.stopWatchers.push(watch(() => this.ValCodpsw.value, (newValue, oldValue) => this.onUpdate('group_psw.codpsw', this.ValCodpsw, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableGroupName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableGroupName',
			originId: 'ValName',
			area: 'GROUP',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableGroupName))
		this.stopWatchers.push(watch(() => this.TableGroupName.value, (newValue, oldValue) => this.onUpdate('group.name', this.TableGroupName, newValue, oldValue)))

		this.TablePswNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePswNome',
			originId: 'ValNome',
			area: 'PSW',
			field: 'NOME',
			maxLength: 100,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePswNome))
		this.stopWatchers.push(watch(() => this.TablePswNome.value, (newValue, oldValue) => this.onUpdate('psw.nome', this.TablePswNome, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormGroupPswViewModel instance.
	 * @returns {QFormGroupPswViewModel} A new instance of QFormGroupPswViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodgroup_psw'

	get QPrimaryKey() { return this.ValCodgroup_psw.value }
	set QPrimaryKey(value) { this.ValCodgroup_psw.updateValue(value) }
}
