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
			name: 'MEMBER_PSW',
			area: 'MEMBER_PSW',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Member_psw',
				updateFilesTickets: 'UpdateFilesTicketsMember_psw',
				setFile: 'SetFileMember_psw'
			}
		})

		/** The primary key. */
		this.ValCodmember_psw = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmember_psw',
			originId: 'ValCodmember_psw',
			area: 'MEMBER_PSW',
			field: 'CODMEMBER_PSW',
			description: '',
		}).cloneFrom(values?.ValCodmember_psw))
		this.stopWatchers.push(watch(() => this.ValCodmember_psw.value, (newValue, oldValue) => this.onUpdate('member_psw.codmember_psw', this.ValCodmember_psw, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValMember_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValMember_id',
			originId: 'ValMember_id',
			area: 'MEMBER_PSW',
			field: 'MEMBER_ID',
			relatedArea: 'MEMBER',
			description: computed(() => this.Resources.MEMBER00534),
		}).cloneFrom(values?.ValMember_id))
		this.stopWatchers.push(watch(() => this.ValMember_id.value, (newValue, oldValue) => this.onUpdate('member_psw.member_id', this.ValMember_id, newValue, oldValue)))

		this.ValPsw_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValPsw_id',
			originId: 'ValPsw_id',
			area: 'MEMBER_PSW',
			field: 'PSW_ID',
			relatedArea: 'PSW',
			description: computed(() => this.Resources.PSW13972),
		}).cloneFrom(values?.ValPsw_id))
		this.stopWatchers.push(watch(() => this.ValPsw_id.value, (newValue, oldValue) => this.onUpdate('member_psw.psw_id', this.ValPsw_id, newValue, oldValue)))

		/** The remaining form fields. */
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
	 * Creates a clone of the current QFormMemberPswViewModel instance.
	 * @returns {QFormMemberPswViewModel} A new instance of QFormMemberPswViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmember_psw'

	get QPrimaryKey() { return this.ValCodmember_psw.value }
	set QPrimaryKey(value) { this.ValCodmember_psw.updateValue(value) }
}
