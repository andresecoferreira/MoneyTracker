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
			name: 'MEMBER',
			area: 'MEMBER',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Member',
				updateFilesTickets: 'UpdateFilesTicketsMember',
				setFile: 'SetFileMember'
			}
		})

		/** The primary key. */
		this.ValCodmember = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmember',
			originId: 'ValCodmember',
			area: 'MEMBER',
			field: 'CODMEMBER',
			description: '',
		}).cloneFrom(values?.ValCodmember))
		this.stopWatchers.push(watch(() => this.ValCodmember.value, (newValue, oldValue) => this.onUpdate('member.codmember', this.ValCodmember, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValGroup_id = reactive(new modelFieldType.ForeignKey({
			id: 'ValGroup_id',
			originId: 'ValGroup_id',
			area: 'MEMBER',
			field: 'GROUP_ID',
			relatedArea: 'GROUP',
			description: computed(() => this.Resources.GROUP38232),
		}).cloneFrom(values?.ValGroup_id))
		this.stopWatchers.push(watch(() => this.ValGroup_id.value, (newValue, oldValue) => this.onUpdate('member.group_id', this.ValGroup_id, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'MEMBER',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('member.photo', this.ValPhoto, newValue, oldValue)))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'MEMBER',
			field: 'NAME',
			maxLength: 80,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('member.name', this.ValName, newValue, oldValue)))

		this.ValBirthday = reactive(new modelFieldType.Date({
			id: 'ValBirthday',
			originId: 'ValBirthday',
			area: 'MEMBER',
			field: 'BIRTHDAY',
			description: computed(() => this.Resources.BIRTHDAY30236),
		}).cloneFrom(values?.ValBirthday))
		this.stopWatchers.push(watch(() => this.ValBirthday.value, (newValue, oldValue) => this.onUpdate('member.birthday', this.ValBirthday, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'MEMBER',
			field: 'EMAIL',
			maxLength: 50,
			maskType: 'EM',
			description: computed(() => this.Resources.E_MAIL26803),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('member.email', this.ValEmail, newValue, oldValue)))

		this.ValPhone = reactive(new modelFieldType.String({
			id: 'ValPhone',
			originId: 'ValPhone',
			area: 'MEMBER',
			field: 'PHONE',
			maxLength: 15,
			description: computed(() => this.Resources.PHONE56703),
		}).cloneFrom(values?.ValPhone))
		this.stopWatchers.push(watch(() => this.ValPhone.value, (newValue, oldValue) => this.onUpdate('member.phone', this.ValPhone, newValue, oldValue)))

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
	}

	/**
	 * Creates a clone of the current QFormMemberViewModel instance.
	 * @returns {QFormMemberViewModel} A new instance of QFormMemberViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmember'

	get QPrimaryKey() { return this.ValCodmember.value }
	set QPrimaryKey(value) { this.ValCodmember.updateValue(value) }
}
