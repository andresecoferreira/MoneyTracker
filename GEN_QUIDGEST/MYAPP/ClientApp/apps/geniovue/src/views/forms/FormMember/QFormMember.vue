<template>
	<teleport
		v-if="formModalIsReady && showFormHeader"
		:to="`#${uiContainersId.header}`"
		:disabled="!isPopup || isNested">
		<div
			ref="formHeader"
			:class="{ 'c-sticky-header': isStickyHeader, 'sticky-top': isStickyTop }">
			<div
				v-if="showFormHeader"
				class="c-action-bar">
				<h1
					v-if="formControl.uiComponents.header && formInfo.designation"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-toggle-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-toggle-group-item
									v-if="showFormHeaderButton(btn)"
									:model-value="btn.isSelected"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									@click="btn.action">
									<template v-if="btn.icon">
										<q-badge-indicator
											:enabled="btn.badge?.isVisible ?? false"
											:color="btn.badge?.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
									</template>
								</q-toggle-group-item>
							</template>
						</q-toggle-group>
					</template>
				</div>
			</div>

			<q-anchor-container-horizontal
				v-if="$app.layout.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
				:anchors="anchorGroups"
				:controls="visibleControls"
				@focus-control="focusControl" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:messages="validationErrors"
			@error-clicked="focusField" />

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<q-container
			fluid
			data-key="MEMBER"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.MEMBER__PSEUDNEWGRP01.isVisible">
					<q-col v-if="controls.MEMBER__PSEUDNEWGRP01.isVisible">
						<q-group-box-container
							v-if="controls.MEMBER__PSEUDNEWGRP01.isVisible"
							id="MEMBER__PSEUDNEWGRP01"
							v-bind="controls.MEMBER__PSEUDNEWGRP01"
							:is-visible="controls.MEMBER__PSEUDNEWGRP01.isVisible">
							<!-- Start MEMBER__PSEUDNEWGRP01 -->
							<q-row v-if="controls.MEMBER__MEMBER__PHOTO.isVisible">
								<q-col v-if="controls.MEMBER__MEMBER__PHOTO.isVisible">
									<base-input-structure
										v-if="controls.MEMBER__MEMBER__PHOTO.isVisible"
										class="q-image"
										v-bind="controls.MEMBER__MEMBER__PHOTO"
										v-on="controls.MEMBER__MEMBER__PHOTO.handlers"
										:loading="controls.MEMBER__MEMBER__PHOTO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.MEMBER__MEMBER__PHOTO.isVisible"
											v-bind="controls.MEMBER__MEMBER__PHOTO.props"
											v-on="controls.MEMBER__MEMBER__PHOTO.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.MEMBER__MEMBER__NAME.isVisible || controls.MEMBER__MEMBER__BIRTHDAY.isVisible">
								<q-col
									v-if="controls.MEMBER__MEMBER__NAME.isVisible || controls.MEMBER__MEMBER__BIRTHDAY.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.MEMBER__MEMBER__NAME.isVisible"
										class="i-text"
										v-bind="controls.MEMBER__MEMBER__NAME"
										v-on="controls.MEMBER__MEMBER__NAME.handlers"
										:loading="controls.MEMBER__MEMBER__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.MEMBER__MEMBER__NAME.props"
											@blur="onBlur(controls.MEMBER__MEMBER__NAME, model.ValName.value)"
											@change="model.ValName.fnUpdateValueOnChange" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.MEMBER__MEMBER__BIRTHDAY.isVisible"
										class="i-text"
										v-bind="controls.MEMBER__MEMBER__BIRTHDAY"
										v-on="controls.MEMBER__MEMBER__BIRTHDAY.handlers"
										:loading="controls.MEMBER__MEMBER__BIRTHDAY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.MEMBER__MEMBER__BIRTHDAY.isVisible"
											v-bind="controls.MEMBER__MEMBER__BIRTHDAY.props"
											:model-value="model.ValBirthday.value"
											@reset-icon-click="model.ValBirthday.fnUpdateValue(model.ValBirthday.originalValue ?? new Date())"
											@update:model-value="model.ValBirthday.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.MEMBER__MEMBER__EMAIL.isVisible || controls.MEMBER__MEMBER__PHONE.isVisible">
								<q-col
									v-if="controls.MEMBER__MEMBER__EMAIL.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.MEMBER__MEMBER__EMAIL.isVisible"
										class="i-text"
										v-bind="controls.MEMBER__MEMBER__EMAIL"
										v-on="controls.MEMBER__MEMBER__EMAIL.handlers"
										:loading="controls.MEMBER__MEMBER__EMAIL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-mask
											v-if="controls.MEMBER__MEMBER__EMAIL.isVisible"
											v-bind="controls.MEMBER__MEMBER__EMAIL"
											:model-value="model.ValEmail.value"
											@change="model.ValEmail.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.MEMBER__MEMBER__PHONE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.MEMBER__MEMBER__PHONE.isVisible"
										class="i-text"
										v-bind="controls.MEMBER__MEMBER__PHONE"
										v-on="controls.MEMBER__MEMBER__PHONE.handlers"
										:loading="controls.MEMBER__MEMBER__PHONE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.MEMBER__MEMBER__PHONE.props"
											@blur="onBlur(controls.MEMBER__MEMBER__PHONE, model.ValPhone.value)"
											@change="model.ValPhone.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.MEMBER__GROUPNAME____.isVisible">
								<q-col
									v-if="controls.MEMBER__GROUPNAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.MEMBER__GROUPNAME____.isVisible"
										class="i-text"
										v-bind="controls.MEMBER__GROUPNAME____"
										v-on="controls.MEMBER__GROUPNAME____.handlers"
										:loading="controls.MEMBER__GROUPNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.MEMBER__GROUPNAME____.isVisible"
											v-bind="controls.MEMBER__GROUPNAME____.props"
											v-on="controls.MEMBER__GROUPNAME____.handlers" />
										<q-see-more-member-groupname
											v-if="controls.MEMBER__GROUPNAME____.seeMoreIsVisible"
											v-bind="controls.MEMBER__GROUPNAME____.seeMoreParams"
											v-on="controls.MEMBER__GROUPNAME____.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End MEMBER__PSEUDNEWGRP01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.MEMBER__PSEUDNEWGRP03.isVisible">
					<q-col v-if="controls.MEMBER__PSEUDNEWGRP03.isVisible">
						<q-group-box-container
							v-if="controls.MEMBER__PSEUDNEWGRP03.isVisible"
							id="MEMBER__PSEUDNEWGRP03"
							v-bind="controls.MEMBER__PSEUDNEWGRP03"
							:is-visible="controls.MEMBER__PSEUDNEWGRP03.isVisible">
							<!-- Start MEMBER__PSEUDNEWGRP03 -->
							<q-row v-if="controls.MEMBER__PSEUDSOURCES_.isVisible">
								<q-col
									v-if="controls.MEMBER__PSEUDSOURCES_.isVisible"
									cols="auto">
									<q-table
										v-if="controls.MEMBER__PSEUDSOURCES_.isVisible"
										v-bind="controls.MEMBER__PSEUDSOURCES_"
										v-on="controls.MEMBER__PSEUDSOURCES_.handlers">
										<template #header>
											<q-table-config
												:table-ctrl="controls.MEMBER__PSEUDSOURCES_"
												v-on="controls.MEMBER__PSEUDSOURCES_.handlers" />
										</template>
										<!-- USE /[MANUAL MNT CUSTOM_TABLE MEMBER__PSEUDSOURCES_]/ -->
									</q-table>
								</q-col>
							</q-row>
							<!-- End MEMBER__PSEUDNEWGRP03 -->
						</q-group-box-container>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<q-divider v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'
	import { useRoute } from 'vue-router'

	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@quidgest/clientapp/network'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import FormViewModel from './QFormMemberViewModel.js'

	const requiredTextResources = ['QFormMember', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FORM_INCLUDEJS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormMember',

		components: {
			QSeeMoreMemberGroupname: defineAsyncComponent(() => import('@/views/forms/FormMember/dbedits/MemberGroupnameSeeMore.vue')),
		},

		mixins: [
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'MEMBER',
					location: 'form-MEMBER',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
			'cancel',
			'initFormProperties',
			'navigationId'
		],

		setup(props)
		{
			const route = useRoute()

			return {
				/*
				 * As properties are reactive, when using $route.params, then when we exit it updates cached components.
				 * Properties have no value and this creates an error in new versions of vue-router.
				 * That's why the value has to be copied to a local property to be used in the router-link tag.
				 */
				currentRouteParams: props.isNested ? {} : route.params
			}
		},

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormMember', false),

				interfaceMetadata: {
					id: 'QFormMember', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'MEMBER',
					route: 'form-MEMBER',
					area: 'MEMBER',
					primaryKey: 'ValCodmember',
					designation: computed(() => this.Resources.MEMBER00534),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: '',
					availableAgents: [],
				},

				formButtons: {
					changeToShow: {
						id: 'change-to-show-btn',
						icon: {
							icon: 'view',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.view]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.show === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToShowMode
					},
					changeToEdit: {
						id: 'change-to-edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.edit === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToEditMode
					},
					changeToDuplicate: {
						id: 'change-to-dup-btn',
						icon: {
							icon: 'duplicate',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.duplicate]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.duplicate === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.new !== vm.formInfo.mode),
						action: vm.changeToDupMode
					},
					changeToDelete: {
						id: 'change-to-delete-btn',
						icon: {
							icon: 'delete',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.delete === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToDeleteMode
					},
					changeToInsert: {
						id: 'change-to-insert-btn',
						icon: {
							icon: 'add',
							type: 'svg'
						},
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.new === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.duplicate !== vm.formInfo.mode),
						action: vm.changeToInsertMode
					},
					repeatInsertBtn: {
						id: 'repeat-insert-btn',
						icon: {
							icon: 'save-new',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.repeatInsert]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.GRAVAR45301),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.saveForm,
						badge: {
							isVisible: computed(() => vm.model?.isDirty === true),
							color: 'highlight'
						}
					},
					confirmBtn: {
						id: 'confirm-btn',
						icon: {
							icon: 'check',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[vm.isNested ? hardcodedTexts.delete : hardcodedTexts.confirm]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && (vm.formInfo.mode === vm.formModes.delete || vm.isNested)),
						action: vm.deleteRecord
					},
					cancelBtn: {
						id: 'cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.CANCELAR49513),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.leaveForm
					},
					resetCancelBtn: {
						id: 'reset-cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.cancel]),
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: () => vm.model.resetValues(),
						emitAction: {
							name: 'deselect',
							params: {}
						}
					},
					editBtn: {
						id: 'edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && vm.parentFormMode !== vm.formModes.delete),
						action: () => {},
						emitAction: {
							name: 'edit',
							params: {}
						}
					},
					deleteQuickBtn: {
						id: 'delete-btn',
						icon: {
							icon: 'bin',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && (typeof vm.permissions.canDelete === 'boolean' ? vm.permissions.canDelete : true)),
						action: vm.deleteRecord
					},
					backBtn: {
						id: 'back-btn',
						icon: {
							icon: 'back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.isPopup ? vm.Resources[hardcodedTexts.close] : vm.Resources[hardcodedTexts.goBack]),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					MEMBER__PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'MEMBER__PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.INFO27076),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['MEMBER__MEMBER__PHOTO', 'MEMBER__MEMBER__NAME', 'MEMBER__MEMBER__BIRTHDAY', 'MEMBER__MEMBER__EMAIL', 'MEMBER__MEMBER__PHONE', 'MEMBER__GROUPNAME____'],
						controlLimits: [
						],
					}, this),
					MEMBER__MEMBER__PHOTO: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:member.photo',
						id: 'MEMBER__MEMBER__PHOTO',
						name: 'PHOTO',
						size: 'block',
						label: computed(() => this.Resources.PHOTO51874),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'MEMBER__PSEUDNEWGRP01',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO51874)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					MEMBER__MEMBER__NAME: new fieldControlClass.StringControl({
						modelField: 'ValName',
						valueChangeEvent: 'fieldChange:member.name',
						id: 'MEMBER__MEMBER__NAME',
						name: 'NAME',
						size: 'xlarge',
						label: computed(() => this.Resources.NAME31974),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'MEMBER__PSEUDNEWGRP01',
						maxLength: 80,
						controlLimits: [
						],
					}, this),
					MEMBER__MEMBER__BIRTHDAY: new fieldControlClass.DateControl({
						modelField: 'ValBirthday',
						valueChangeEvent: 'fieldChange:member.birthday',
						id: 'MEMBER__MEMBER__BIRTHDAY',
						name: 'BIRTHDAY',
						size: 'small',
						label: computed(() => this.Resources.BIRTHDAY30236),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'MEMBER__PSEUDNEWGRP01',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					MEMBER__MEMBER__EMAIL: new fieldControlClass.MaskControl({
						modelField: 'ValEmail',
						valueChangeEvent: 'fieldChange:member.email',
						id: 'MEMBER__MEMBER__EMAIL',
						name: 'EMAIL',
						size: 'xlarge',
						label: computed(() => this.Resources.E_MAIL26803),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'MEMBER__PSEUDNEWGRP01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					MEMBER__MEMBER__PHONE: new fieldControlClass.StringControl({
						modelField: 'ValPhone',
						valueChangeEvent: 'fieldChange:member.phone',
						id: 'MEMBER__MEMBER__PHONE',
						name: 'PHONE',
						size: 'small',
						label: computed(() => this.Resources.PHONE56703),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'MEMBER__PSEUDNEWGRP01',
						maxLength: 15,
						controlLimits: [
						],
					}, this),
					MEMBER__GROUPNAME____: new fieldControlClass.LookupControl({
						modelField: 'TableGroupName',
						valueChangeEvent: 'fieldChange:group.name',
						id: 'MEMBER__GROUPNAME____',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.GROUP38232),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'MEMBER__PSEUDNEWGRP01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValGroup_id',
							dependencyEvent: 'fieldChange:member.group_id'
						},
						dependentFields: () => ({
							set 'group.codgroup'(value) { vm.model.ValGroup_id.updateValue(value) },
							set 'group.name'(value) { vm.model.TableGroupName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					MEMBER__PSEUDNEWGRP03: new fieldControlClass.GroupControl({
						id: 'MEMBER__PSEUDNEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.ACCOUNTS54906),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['MEMBER__PSEUDSOURCES_'],
						controlLimits: [
						],
					}, this),
					MEMBER__PSEUDSOURCES_: new fieldControlClass.TableListControl({
						id: 'MEMBER__PSEUDSOURCES_',
						name: 'SOURCES',
						size: 'xxlarge',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'MEMBER__PSEUDNEWGRP03',
						controller: 'MEMBER',
						action: 'Member_ValSources',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.ArrayColumn({
								order: 1,
								name: 'ValType',
								area: 'SOURCE',
								field: 'TYPE',
								label: computed(() => this.Resources.TYPE00312),
								dataLength: 2,
								scrollData: 2,
								export: 1,
								array: computed(() => new qProjArrays.QArrayAccout_type(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayAccout_type.type,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValTitle',
								area: 'SOURCE',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE21885),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValSources',
							serverMode: true,
							pkColumn: 'ValCodsource',
							tableAlias: 'SOURCE',
							tableNamePlural: computed(() => this.Resources.ACCOUNTS54906),
							viewManagement: '',
							showLimitsInfo: true,
							perPage: 5,
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							allowColumnFilters: false,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'SOURCE',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'SOURCE',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'SOURCE',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'SOURCE',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'SOURCE',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__SOURCE',
								name: '_SOURCE',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'SOURCE',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'SOURCE': {
									fnKeySelector: (row) => row.Fields.ValCodsource,
									isPopup: true
								},
							},
							defaultSearchColumnName: 'ValTitle',
							defaultSearchColumnNameOriginal: 'ValTitle',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-MEMBER', 'changed-SOURCE'],
						uuid: 'Member_ValSources',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'member'],
								dependencyEvents: ['fieldChange:member.codmember'],
								dependencyField: 'MEMBER.CODMEMBER',
								fnValueSelector: (model) => model.ValCodmember.value
							},
						],
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'MEMBER__PSEUDNEWGRP01',
					'MEMBER__PSEUDNEWGRP03',
				]),

				tableFields: readonly([
					'MEMBER__PSEUDSOURCES_',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Group: {
						get ValName() { return vm.model.TableGroupName.value },
						set ValName(value) { vm.model.TableGroupName.updateValue(value) },
					},
					Member: {
						get ValBirthday() { return vm.model.ValBirthday.value },
						set ValBirthday(value) { vm.model.ValBirthday.updateValue(value) },
						get ValEmail() { return vm.model.ValEmail.value },
						set ValEmail(value) { vm.model.ValEmail.updateValue(value) },
						get ValGroup_id() { return vm.model.ValGroup_id.value },
						set ValGroup_id(value) { vm.model.ValGroup_id.updateValue(value) },
						get ValName() { return vm.model.ValName.value },
						set ValName(value) { vm.model.ValName.updateValue(value) },
						get ValPhone() { return vm.model.ValPhone.value },
						set ValPhone(value) { vm.model.ValPhone.updateValue(value) },
						get ValPhoto() { return vm.model.ValPhoto.value },
						set ValPhoto(value) { vm.model.ValPhoto.updateValue(value) },
					},
					keys: {
						/** The primary key of the MEMBER table */
						get member() { return vm.model.ValCodmember },
						/** The foreign key to the GROUP table */
						get group() { return vm.model.ValGroup_id },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			next((vm) => {
				vm.initFormProperties(to)
			})
		},

		beforeRouteLeave(to, _, next)
		{
			if (to.params.isControlled === 'true')
			{
				genericFunctions.setNavigationState(false)
				next()
			}
			else
				this.cancel(next)
		},

		beforeRouteUpdate(to, _, next)
		{
			if (to.params.isControlled === 'true')
				next()
			else
				this.cancel(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FORM_CODEJS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT COMPONENT_BEFORE_UNMOUNT MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT BEFORE_LOAD_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FORM_LOADED_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before an apply action is performed.
			 */
			async beforeApply()
			{
				let applyForm = true // Set to 'false' to cancel form apply.

				// Execute the "Before apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets(true)
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					applyForm = await changesPromise

					if (applyForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						applyForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT BEFORE_APPLY_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return applyForm
			},

			/**
			 * Called after an apply action is performed.
			 */
			async afterApply()
			{
				// Execute the "After apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT AFTER_APPLY_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before the record is saved.
			 */
			async beforeSave()
			{
				let saveForm = true // Set to 'false' to cancel form saving.

				// Execute the "Before save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets()
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					saveForm = await changesPromise

					if (saveForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						saveForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT BEFORE_SAVE_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return saveForm
			},

			/**
			 * Called after the record is saved.
			 */
			async afterSave()
			{
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT AFTER_SAVE_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT BEFORE_DEL_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT AFTER_DEL_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT BEFORE_EXIT_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT AFTER_EXIT_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called whenever a field's value is updated.
			 * @param {string} fieldName The name of the field in the format [table].[field] (ex: 'person.name')
			 * @param {object} fieldObject The object representing the field in the model
			 * @param {any} fieldValue The value of the field
			 * @param {any} oldFieldValue The previous value of the field
			 */
			// eslint-disable-next-line
			onUpdate(fieldName, fieldObject, fieldValue, oldFieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT DLGUPDT MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
			},

			/**
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT CTRLBLR MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUnfocus(fieldObject, fieldValue)
			},

			/**
			 * Called whenever a control's value is updated.
			 * @param {string} controlField The name of the field in the controls that will be updated
			 * @param {object} control The object representing the field in the controls
			 * @param {any} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onControlUpdate(controlField, control, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT CTRLUPD MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FUNCTIONS_JS MEMBER]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
