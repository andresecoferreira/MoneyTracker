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
			data-key="SOURCE"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.SOURCE__PSEUDNEWGRP04.isVisible">
					<q-col v-if="controls.SOURCE__PSEUDNEWGRP04.isVisible">
						<q-accordion
							v-if="controls.SOURCE__PSEUDNEWGRP04.isVisible"
							id="SOURCE__PSEUDNEWGRP04"
							v-model="controls.SOURCE__PSEUDNEWGRP04.openChild">
							<!-- Start SOURCE__PSEUDNEWGRP04 -->
							<q-accordion-item
								v-if="controls.SOURCE__PSEUDNEWGRP01.isVisible"
								id="SOURCE__PSEUDNEWGRP01-container"
								value="SOURCE__PSEUDNEWGRP01"
								:title="controls.SOURCE__PSEUDNEWGRP01.label">
								<!-- Start SOURCE__PSEUDNEWGRP01 -->
								<q-row v-if="controls.SOURCE__SOURCE__TYPE.isVisible || controls.SOURCE__MEMBER__NAME.isVisible">
									<q-col
										v-if="controls.SOURCE__SOURCE__TYPE.isVisible || controls.SOURCE__MEMBER__NAME.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.SOURCE__SOURCE__TYPE.isVisible"
											class="i-text"
											v-bind="controls.SOURCE__SOURCE__TYPE"
											v-on="controls.SOURCE__SOURCE__TYPE.handlers"
											:loading="controls.SOURCE__SOURCE__TYPE.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-select
												v-if="controls.SOURCE__SOURCE__TYPE.isVisible"
												v-bind="controls.SOURCE__SOURCE__TYPE.props"
												@update:model-value="model.ValType.fnUpdateValue" />
										</base-input-structure>
										<base-input-structure
											v-if="controls.SOURCE__MEMBER__NAME.isVisible"
											class="i-text"
											v-bind="controls.SOURCE__MEMBER__NAME"
											v-on="controls.SOURCE__MEMBER__NAME.handlers"
											:loading="controls.SOURCE__MEMBER__NAME.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-lookup
												v-if="controls.SOURCE__MEMBER__NAME.isVisible"
												v-bind="controls.SOURCE__MEMBER__NAME.props"
												v-on="controls.SOURCE__MEMBER__NAME.handlers" />
											<q-see-more-source-member-name
												v-if="controls.SOURCE__MEMBER__NAME.seeMoreIsVisible"
												v-bind="controls.SOURCE__MEMBER__NAME.seeMoreParams"
												v-on="controls.SOURCE__MEMBER__NAME.handlers" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.SOURCE__SOURCE__TITLE.isVisible">
									<q-col
										v-if="controls.SOURCE__SOURCE__TITLE.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.SOURCE__SOURCE__TITLE.isVisible"
											class="i-text"
											v-bind="controls.SOURCE__SOURCE__TITLE"
											v-on="controls.SOURCE__SOURCE__TITLE.handlers"
											:loading="controls.SOURCE__SOURCE__TITLE.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.SOURCE__SOURCE__TITLE.props"
												@blur="onBlur(controls.SOURCE__SOURCE__TITLE, model.ValTitle.value)"
												@change="model.ValTitle.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<!-- End SOURCE__PSEUDNEWGRP01 -->
							</q-accordion-item>
							<q-accordion-item
								v-if="controls.SOURCE__PSEUDNEWGRP02.isVisible"
								id="SOURCE__PSEUDNEWGRP02-container"
								value="SOURCE__PSEUDNEWGRP02"
								:title="controls.SOURCE__PSEUDNEWGRP02.label">
								<!-- Start SOURCE__PSEUDNEWGRP02 -->
								<q-row v-if="controls.SOURCE__SOURCE__BANK.isVisible || controls.SOURCE__SOURCE__ACCOUNT_NUMBER.isVisible">
									<q-col
										v-if="controls.SOURCE__SOURCE__BANK.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.SOURCE__SOURCE__BANK.isVisible"
											class="i-text"
											v-bind="controls.SOURCE__SOURCE__BANK"
											v-on="controls.SOURCE__SOURCE__BANK.handlers"
											:loading="controls.SOURCE__SOURCE__BANK.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-select
												v-if="controls.SOURCE__SOURCE__BANK.isVisible"
												v-bind="controls.SOURCE__SOURCE__BANK.props"
												@update:model-value="model.ValBank.fnUpdateValue" />
										</base-input-structure>
									</q-col>
									<q-col
										v-if="controls.SOURCE__SOURCE__ACCOUNT_NUMBER.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.SOURCE__SOURCE__ACCOUNT_NUMBER.isVisible"
											class="i-text"
											v-bind="controls.SOURCE__SOURCE__ACCOUNT_NUMBER"
											v-on="controls.SOURCE__SOURCE__ACCOUNT_NUMBER.handlers"
											:loading="controls.SOURCE__SOURCE__ACCOUNT_NUMBER.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-text-field
												v-bind="controls.SOURCE__SOURCE__ACCOUNT_NUMBER.props"
												@blur="onBlur(controls.SOURCE__SOURCE__ACCOUNT_NUMBER, model.ValAccount_number.value)"
												@change="model.ValAccount_number.fnUpdateValueOnChange" />
										</base-input-structure>
									</q-col>
								</q-row>
								<q-row v-if="controls.SOURCE__SOURCE__BALANCE.isVisible">
									<q-col
										v-if="controls.SOURCE__SOURCE__BALANCE.isVisible"
										cols="auto">
										<base-input-structure
											v-if="controls.SOURCE__SOURCE__BALANCE.isVisible"
											class="i-text"
											v-bind="controls.SOURCE__SOURCE__BALANCE"
											v-on="controls.SOURCE__SOURCE__BALANCE.handlers"
											:loading="controls.SOURCE__SOURCE__BALANCE.props.loading"
											:reporting-mode-on="reportingModeCAV"
											:suggestion-mode-on="suggestionModeOn">
											<q-numeric-input
												v-if="controls.SOURCE__SOURCE__BALANCE.isVisible"
												v-bind="controls.SOURCE__SOURCE__BALANCE.props"
												@update:model-value="model.ValBalance.fnUpdateValue" />
										</base-input-structure>
									</q-col>
								</q-row>
								<!-- End SOURCE__PSEUDNEWGRP02 -->
							</q-accordion-item>
							<!-- End SOURCE__PSEUDNEWGRP04 -->
						</q-accordion>
					</q-col>
				</q-row>
				<q-row v-if="controls.SOURCE__PSEUDNEWGRP05.isVisible">
					<q-col v-if="controls.SOURCE__PSEUDNEWGRP05.isVisible">
						<q-group-box-container
							v-if="controls.SOURCE__PSEUDNEWGRP05.isVisible"
							id="SOURCE__PSEUDNEWGRP05"
							v-bind="controls.SOURCE__PSEUDNEWGRP05"
							:is-visible="controls.SOURCE__PSEUDNEWGRP05.isVisible">
							<!-- Start SOURCE__PSEUDNEWGRP05 -->
							<q-row v-if="controls.SOURCE__PSEUDNEWGRP03.isVisible">
								<q-col v-if="controls.SOURCE__PSEUDNEWGRP03.isVisible">
									<q-group-box-container
										v-if="controls.SOURCE__PSEUDNEWGRP03.isVisible"
										id="SOURCE__PSEUDNEWGRP03"
										v-bind="controls.SOURCE__PSEUDNEWGRP03"
										:is-visible="controls.SOURCE__PSEUDNEWGRP03.isVisible">
										<!-- Start SOURCE__PSEUDNEWGRP03 -->
										<q-row v-if="controls.SOURCE__SOURCE__CREATED_AT.isVisible || controls.SOURCE__SOURCE__CREATED_BY.isVisible">
											<q-col
												v-if="controls.SOURCE__SOURCE__CREATED_AT.isVisible || controls.SOURCE__SOURCE__CREATED_BY.isVisible"
												cols="auto">
												<base-input-structure
													v-if="controls.SOURCE__SOURCE__CREATED_AT.isVisible"
													class="i-text"
													v-bind="controls.SOURCE__SOURCE__CREATED_AT"
													v-on="controls.SOURCE__SOURCE__CREATED_AT.handlers"
													:loading="controls.SOURCE__SOURCE__CREATED_AT.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-date-time-picker
														v-if="controls.SOURCE__SOURCE__CREATED_AT.isVisible"
														v-bind="controls.SOURCE__SOURCE__CREATED_AT.props"
														:model-value="model.ValCreated_at.value"
														@reset-icon-click="model.ValCreated_at.fnUpdateValue(model.ValCreated_at.originalValue ?? new Date())"
														@update:model-value="model.ValCreated_at.fnUpdateValue($event ?? '')" />
												</base-input-structure>
												<base-input-structure
													v-if="controls.SOURCE__SOURCE__CREATED_BY.isVisible"
													class="i-text"
													v-bind="controls.SOURCE__SOURCE__CREATED_BY"
													v-on="controls.SOURCE__SOURCE__CREATED_BY.handlers"
													:loading="controls.SOURCE__SOURCE__CREATED_BY.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.SOURCE__SOURCE__CREATED_BY.props"
														@blur="onBlur(controls.SOURCE__SOURCE__CREATED_BY, model.ValCreated_by.value)"
														@change="model.ValCreated_by.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-col>
										</q-row>
										<q-row v-if="controls.SOURCE__SOURCE__UPDATED_AT.isVisible || controls.SOURCE__SOURCE__UPDATED_BY.isVisible">
											<q-col
												v-if="controls.SOURCE__SOURCE__UPDATED_AT.isVisible"
												cols="auto">
												<base-input-structure
													v-if="controls.SOURCE__SOURCE__UPDATED_AT.isVisible"
													class="i-text"
													v-bind="controls.SOURCE__SOURCE__UPDATED_AT"
													v-on="controls.SOURCE__SOURCE__UPDATED_AT.handlers"
													:loading="controls.SOURCE__SOURCE__UPDATED_AT.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-date-time-picker
														v-if="controls.SOURCE__SOURCE__UPDATED_AT.isVisible"
														v-bind="controls.SOURCE__SOURCE__UPDATED_AT.props"
														:model-value="model.ValUpdated_at.value"
														@reset-icon-click="model.ValUpdated_at.fnUpdateValue(model.ValUpdated_at.originalValue ?? new Date())"
														@update:model-value="model.ValUpdated_at.fnUpdateValue($event ?? '')" />
												</base-input-structure>
											</q-col>
											<q-col
												v-if="controls.SOURCE__SOURCE__UPDATED_BY.isVisible"
												cols="auto">
												<base-input-structure
													v-if="controls.SOURCE__SOURCE__UPDATED_BY.isVisible"
													class="i-text"
													v-bind="controls.SOURCE__SOURCE__UPDATED_BY"
													v-on="controls.SOURCE__SOURCE__UPDATED_BY.handlers"
													:loading="controls.SOURCE__SOURCE__UPDATED_BY.props.loading"
													:reporting-mode-on="reportingModeCAV"
													:suggestion-mode-on="suggestionModeOn">
													<q-text-field
														v-bind="controls.SOURCE__SOURCE__UPDATED_BY.props"
														@blur="onBlur(controls.SOURCE__SOURCE__UPDATED_BY, model.ValUpdated_by.value)"
														@change="model.ValUpdated_by.fnUpdateValueOnChange" />
												</base-input-structure>
											</q-col>
										</q-row>
										<!-- End SOURCE__PSEUDNEWGRP03 -->
									</q-group-box-container>
								</q-col>
							</q-row>
							<!-- End SOURCE__PSEUDNEWGRP05 -->
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

	import FormViewModel from './QFormSourceViewModel.js'

	const requiredTextResources = ['QFormSource', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FORM_INCLUDEJS SOURCE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormSource',

		components: {
			QSeeMoreSourceMemberName: defineAsyncComponent(() => import('@/views/forms/FormSource/dbedits/SourceMemberNameSeeMore.vue')),
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
					name: 'SOURCE',
					location: 'form-SOURCE',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormSource', false),

				interfaceMetadata: {
					id: 'QFormSource', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'popup',
					name: 'SOURCE',
					route: 'form-SOURCE',
					area: 'SOURCE',
					primaryKey: 'ValCodsource',
					designation: computed(() => this.Resources.ACCOUNT64260),
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
					SOURCE__PSEUDNEWGRP04: new fieldControlClass.AccordionControl({
						id: 'SOURCE__PSEUDNEWGRP04',
						name: 'NEWGRP04',
						size: 'block',
						label: computed(() => this.Resources.NEW_GROUP63448),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['SOURCE__PSEUDNEWGRP01', 'SOURCE__PSEUDNEWGRP02'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					SOURCE__PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'SOURCE__PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.INFO27076),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP04',
						isInAccordion: true,
						isCollapsible: true,
						anchored: false,
						directChildren: ['SOURCE__SOURCE__TYPE', 'SOURCE__MEMBER__NAME', 'SOURCE__SOURCE__TITLE'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					SOURCE__SOURCE__TYPE: new fieldControlClass.ArrayStringControl({
						modelField: 'ValType',
						valueChangeEvent: 'fieldChange:source.type',
						id: 'SOURCE__SOURCE__TYPE',
						name: 'TYPE',
						size: 'medium',
						label: computed(() => this.Resources.TYPE00312),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP01',
						maxLength: 2,
						mustBeFilled: true,
						arrayName: 'Accout_Type',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					SOURCE__MEMBER__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableMemberName',
						valueChangeEvent: 'fieldChange:member.name',
						id: 'SOURCE__MEMBER__NAME',
						name: 'NAME',
						size: 'xlarge',
						label: computed(() => this.Resources.OWNER09558),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValMember_id',
							dependencyEvent: 'fieldChange:source.member_id'
						},
						dependentFields: () => ({
							set 'member.codmember'(value) { vm.model.ValMember_id.updateValue(value) },
							set 'member.name'(value) { vm.model.TableMemberName.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					SOURCE__SOURCE__TITLE: new fieldControlClass.StringControl({
						modelField: 'ValTitle',
						valueChangeEvent: 'fieldChange:source.title',
						id: 'SOURCE__SOURCE__TITLE',
						name: 'TITLE',
						size: 'xxlarge',
						label: computed(() => this.Resources.TITLE21885),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP01',
						maxLength: 50,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					SOURCE__PSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'SOURCE__PSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.DETAILS19591),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP04',
						isInAccordion: true,
						isCollapsible: true,
						anchored: false,
						directChildren: ['SOURCE__SOURCE__BANK', 'SOURCE__SOURCE__ACCOUNT_NUMBER', 'SOURCE__SOURCE__BALANCE'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					SOURCE__SOURCE__BANK: new fieldControlClass.ArrayStringControl({
						modelField: 'ValBank',
						valueChangeEvent: 'fieldChange:source.bank',
						id: 'SOURCE__SOURCE__BANK',
						name: 'BANK',
						size: 'medium',
						label: computed(() => this.Resources.BANK26563),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP02',
						maxLength: 12,
						arrayName: 'Banks',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					SOURCE__SOURCE__ACCOUNT_NUMBER: new fieldControlClass.StringControl({
						modelField: 'ValAccount_number',
						valueChangeEvent: 'fieldChange:source.account_number',
						id: 'SOURCE__SOURCE__ACCOUNT_NUMBER',
						name: 'ACCOUNT_NUMBER',
						size: 'medium',
						label: computed(() => this.Resources.ACCOUNT_NUMBER58504),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP02',
						maxLength: 20,
						controlLimits: [
						],
					}, this),
					SOURCE__SOURCE__BALANCE: new fieldControlClass.NumberControl({
						modelField: 'ValBalance',
						valueChangeEvent: 'fieldChange:source.balance',
						id: 'SOURCE__SOURCE__BALANCE',
						name: 'BALANCE',
						size: 'medium',
						label: computed(() => this.Resources.BALANCE13297),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP02',
						maxIntegers: 12,
						maxDecimals: 2,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					SOURCE__PSEUDNEWGRP05: new fieldControlClass.GroupControl({
						id: 'SOURCE__PSEUDNEWGRP05',
						name: 'NEWGRP05',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['SOURCE__PSEUDNEWGRP03'],
						controlLimits: [
						],
					}, this),
					SOURCE__PSEUDNEWGRP03: new fieldControlClass.GroupControl({
						id: 'SOURCE__PSEUDNEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.CONTROL15481),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP05',
						isCollapsible: false,
						anchored: false,
						directChildren: ['SOURCE__SOURCE__CREATED_AT', 'SOURCE__SOURCE__CREATED_BY', 'SOURCE__SOURCE__UPDATED_AT', 'SOURCE__SOURCE__UPDATED_BY'],
						controlLimits: [
						],
					}, this),
					SOURCE__SOURCE__CREATED_AT: new fieldControlClass.DateControl({
						modelField: 'ValCreated_at',
						valueChangeEvent: 'fieldChange:source.created_at',
						id: 'SOURCE__SOURCE__CREATED_AT',
						name: 'CREATED_AT',
						size: 'small',
						label: computed(() => this.Resources.CREATED_AT09073),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP03',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					SOURCE__SOURCE__CREATED_BY: new fieldControlClass.StringControl({
						modelField: 'ValCreated_by',
						valueChangeEvent: 'fieldChange:source.created_by',
						id: 'SOURCE__SOURCE__CREATED_BY',
						name: 'CREATED_BY',
						size: 'xlarge',
						label: computed(() => this.Resources.CREATED_BY58035),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP03',
						maxLength: 100,
						controlLimits: [
						],
					}, this),
					SOURCE__SOURCE__UPDATED_AT: new fieldControlClass.DateControl({
						modelField: 'ValUpdated_at',
						valueChangeEvent: 'fieldChange:source.updated_at',
						id: 'SOURCE__SOURCE__UPDATED_AT',
						name: 'UPDATED_AT',
						size: 'small',
						label: computed(() => this.Resources.UPDATED_AT48366),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP03',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					SOURCE__SOURCE__UPDATED_BY: new fieldControlClass.StringControl({
						modelField: 'ValUpdated_by',
						valueChangeEvent: 'fieldChange:source.updated_by',
						id: 'SOURCE__SOURCE__UPDATED_BY',
						name: 'UPDATED_BY',
						size: 'xlarge',
						label: computed(() => this.Resources.UPDATED_BY38656),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'SOURCE__PSEUDNEWGRP03',
						maxLength: 100,
						controlLimits: [
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
					'SOURCE__PSEUDNEWGRP04',
					'SOURCE__PSEUDNEWGRP01',
					'SOURCE__PSEUDNEWGRP02',
					'SOURCE__PSEUDNEWGRP05',
					'SOURCE__PSEUDNEWGRP03',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Member: {
						get ValName() { return vm.model.TableMemberName.value },
						set ValName(value) { vm.model.TableMemberName.updateValue(value) },
					},
					Source: {
						get ValAccount_number() { return vm.model.ValAccount_number.value },
						set ValAccount_number(value) { vm.model.ValAccount_number.updateValue(value) },
						get ValBalance() { return vm.model.ValBalance.value },
						set ValBalance(value) { vm.model.ValBalance.updateValue(value) },
						get ValBank() { return vm.model.ValBank.value },
						set ValBank(value) { vm.model.ValBank.updateValue(value) },
						get ValCreated_at() { return vm.model.ValCreated_at.value },
						set ValCreated_at(value) { vm.model.ValCreated_at.updateValue(value) },
						get ValCreated_by() { return vm.model.ValCreated_by.value },
						set ValCreated_by(value) { vm.model.ValCreated_by.updateValue(value) },
						get ValMember_id() { return vm.model.ValMember_id.value },
						set ValMember_id(value) { vm.model.ValMember_id.updateValue(value) },
						get ValTitle() { return vm.model.ValTitle.value },
						set ValTitle(value) { vm.model.ValTitle.updateValue(value) },
						get ValType() { return vm.model.ValType.value },
						set ValType(value) { vm.model.ValType.updateValue(value) },
						get ValUpdated_at() { return vm.model.ValUpdated_at.value },
						set ValUpdated_at(value) { vm.model.ValUpdated_at.updateValue(value) },
						get ValUpdated_by() { return vm.model.ValUpdated_by.value },
						set ValUpdated_by(value) { vm.model.ValUpdated_by.updateValue(value) },
					},
					keys: {
						/** The primary key of the SOURCE table */
						get source() { return vm.model.ValCodsource },
						/** The foreign key to the MEMBER table */
						get member() { return vm.model.ValMember_id },
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
// USE /[MANUAL MNT FORM_CODEJS SOURCE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT COMPONENT_BEFORE_UNMOUNT SOURCE]/
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
// USE /[MANUAL MNT BEFORE_LOAD_JS SOURCE]/
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
// USE /[MANUAL MNT FORM_LOADED_JS SOURCE]/
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
// USE /[MANUAL MNT BEFORE_APPLY_JS SOURCE]/
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
// USE /[MANUAL MNT AFTER_APPLY_JS SOURCE]/
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
// USE /[MANUAL MNT BEFORE_SAVE_JS SOURCE]/
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
// USE /[MANUAL MNT AFTER_SAVE_JS SOURCE]/
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
// USE /[MANUAL MNT BEFORE_DEL_JS SOURCE]/
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
// USE /[MANUAL MNT AFTER_DEL_JS SOURCE]/
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
// USE /[MANUAL MNT BEFORE_EXIT_JS SOURCE]/
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
// USE /[MANUAL MNT AFTER_EXIT_JS SOURCE]/
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
// USE /[MANUAL MNT DLGUPDT SOURCE]/
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
// USE /[MANUAL MNT CTRLBLR SOURCE]/
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
// USE /[MANUAL MNT CTRLUPD SOURCE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FUNCTIONS_JS SOURCE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
