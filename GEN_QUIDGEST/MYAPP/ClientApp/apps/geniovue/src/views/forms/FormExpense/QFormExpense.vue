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
			data-key="EXPENSE"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.EXPENSE__EXPENSE__EXPENSE_ID.isVisible">
					<q-col
						v-if="controls.EXPENSE__EXPENSE__EXPENSE_ID.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.EXPENSE__EXPENSE__EXPENSE_ID.isVisible"
							class="i-text"
							v-bind="controls.EXPENSE__EXPENSE__EXPENSE_ID"
							v-on="controls.EXPENSE__EXPENSE__EXPENSE_ID.handlers"
							:loading="controls.EXPENSE__EXPENSE__EXPENSE_ID.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-numeric-input
								v-if="controls.EXPENSE__EXPENSE__EXPENSE_ID.isVisible"
								v-bind="controls.EXPENSE__EXPENSE__EXPENSE_ID.props"
								@update:model-value="model.ValExpense_id.fnUpdateValue" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.EXPENSE_PSEUDNEWGRP02.isVisible">
					<q-col v-if="controls.EXPENSE_PSEUDNEWGRP02.isVisible">
						<q-group-box-container
							v-if="controls.EXPENSE_PSEUDNEWGRP02.isVisible"
							id="EXPENSE_PSEUDNEWGRP02"
							v-bind="controls.EXPENSE_PSEUDNEWGRP02"
							:is-visible="controls.EXPENSE_PSEUDNEWGRP02.isVisible">
							<!-- Start EXPENSE_PSEUDNEWGRP02 -->
							<q-row v-if="controls.EXPENSE__CATEGORY_TYPE__NAME.isVisible || controls.EXPENSE__CATEGORY__NAME.isVisible">
								<q-col
									v-if="controls.EXPENSE__CATEGORY_TYPE__NAME.isVisible || controls.EXPENSE__CATEGORY__NAME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EXPENSE__CATEGORY_TYPE__NAME.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__CATEGORY_TYPE__NAME"
										v-on="controls.EXPENSE__CATEGORY_TYPE__NAME.handlers"
										:loading="controls.EXPENSE__CATEGORY_TYPE__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EXPENSE__CATEGORY_TYPE__NAME.isVisible"
											v-bind="controls.EXPENSE__CATEGORY_TYPE__NAME.props"
											v-on="controls.EXPENSE__CATEGORY_TYPE__NAME.handlers" />
										<q-see-more-expense-category-type-name
											v-if="controls.EXPENSE__CATEGORY_TYPE__NAME.seeMoreIsVisible"
											v-bind="controls.EXPENSE__CATEGORY_TYPE__NAME.seeMoreParams"
											v-on="controls.EXPENSE__CATEGORY_TYPE__NAME.handlers" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.EXPENSE__CATEGORY__NAME.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__CATEGORY__NAME"
										v-on="controls.EXPENSE__CATEGORY__NAME.handlers"
										:loading="controls.EXPENSE__CATEGORY__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EXPENSE__CATEGORY__NAME.isVisible"
											v-bind="controls.EXPENSE__CATEGORY__NAME.props"
											v-on="controls.EXPENSE__CATEGORY__NAME.handlers" />
										<q-see-more-expense-category-name
											v-if="controls.EXPENSE__CATEGORY__NAME.seeMoreIsVisible"
											v-bind="controls.EXPENSE__CATEGORY__NAME.seeMoreParams"
											v-on="controls.EXPENSE__CATEGORY__NAME.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EXPENSE__MEMBER__NAME.isVisible || controls.EXPENSE_GROUPNAME____.isVisible">
								<q-col
									v-if="controls.EXPENSE__MEMBER__NAME.isVisible || controls.EXPENSE_GROUPNAME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EXPENSE__MEMBER__NAME.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__MEMBER__NAME"
										v-on="controls.EXPENSE__MEMBER__NAME.handlers"
										:loading="controls.EXPENSE__MEMBER__NAME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EXPENSE__MEMBER__NAME.isVisible"
											v-bind="controls.EXPENSE__MEMBER__NAME.props"
											v-on="controls.EXPENSE__MEMBER__NAME.handlers" />
										<q-see-more-expense-member-name
											v-if="controls.EXPENSE__MEMBER__NAME.seeMoreIsVisible"
											v-bind="controls.EXPENSE__MEMBER__NAME.seeMoreParams"
											v-on="controls.EXPENSE__MEMBER__NAME.handlers" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.EXPENSE_GROUPNAME____.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE_GROUPNAME____"
										v-on="controls.EXPENSE_GROUPNAME____.handlers"
										:loading="controls.EXPENSE_GROUPNAME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EXPENSE_GROUPNAME____.props"
											@blur="onBlur(controls.EXPENSE_GROUPNAME____, model.GroupValName.value)"
											@change="model.GroupValName.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EXPENSE__SOURCE__TITLE.isVisible || controls.EXPENSE__EXPENSE__VALUE.isVisible || controls.EXPENSE__EXPENSE__DATE.isVisible || controls.EXPENSE__EXPENSE__MONTH.isVisible || controls.EXPENSE__EXPENSE__YEAR.isVisible">
								<q-col
									v-if="controls.EXPENSE__SOURCE__TITLE.isVisible || controls.EXPENSE__EXPENSE__VALUE.isVisible || controls.EXPENSE__EXPENSE__DATE.isVisible || controls.EXPENSE__EXPENSE__MONTH.isVisible || controls.EXPENSE__EXPENSE__YEAR.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EXPENSE__SOURCE__TITLE.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__SOURCE__TITLE"
										v-on="controls.EXPENSE__SOURCE__TITLE.handlers"
										:loading="controls.EXPENSE__SOURCE__TITLE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.EXPENSE__SOURCE__TITLE.isVisible"
											v-bind="controls.EXPENSE__SOURCE__TITLE.props"
											v-on="controls.EXPENSE__SOURCE__TITLE.handlers" />
										<q-see-more-expense-source-title
											v-if="controls.EXPENSE__SOURCE__TITLE.seeMoreIsVisible"
											v-bind="controls.EXPENSE__SOURCE__TITLE.seeMoreParams"
											v-on="controls.EXPENSE__SOURCE__TITLE.handlers" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__VALUE.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__VALUE"
										v-on="controls.EXPENSE__EXPENSE__VALUE.handlers"
										:loading="controls.EXPENSE__EXPENSE__VALUE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.EXPENSE__EXPENSE__VALUE.isVisible"
											v-bind="controls.EXPENSE__EXPENSE__VALUE.props"
											@update:model-value="model.ValValue.fnUpdateValue" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__DATE.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__DATE"
										v-on="controls.EXPENSE__EXPENSE__DATE.handlers"
										:loading="controls.EXPENSE__EXPENSE__DATE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.EXPENSE__EXPENSE__DATE.isVisible"
											v-bind="controls.EXPENSE__EXPENSE__DATE.props"
											:model-value="model.ValDate.value"
											@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
											@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__MONTH.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__MONTH"
										v-on="controls.EXPENSE__EXPENSE__MONTH.handlers"
										:loading="controls.EXPENSE__EXPENSE__MONTH.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.EXPENSE__EXPENSE__MONTH.isVisible"
											v-bind="controls.EXPENSE__EXPENSE__MONTH.props" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__YEAR.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__YEAR"
										v-on="controls.EXPENSE__EXPENSE__YEAR.handlers"
										:loading="controls.EXPENSE__EXPENSE__YEAR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.EXPENSE__EXPENSE__YEAR.isVisible"
											v-bind="controls.EXPENSE__EXPENSE__YEAR.props" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EXPENSE__EXPENSE__DESCRIPTION.isVisible || controls.EXPENSE__EXPENSE__INVOICE.isVisible">
								<q-col
									v-if="controls.EXPENSE__EXPENSE__DESCRIPTION.isVisible || controls.EXPENSE__EXPENSE__INVOICE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__DESCRIPTION.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__DESCRIPTION"
										v-on="controls.EXPENSE__EXPENSE__DESCRIPTION.handlers"
										:loading="controls.EXPENSE__EXPENSE__DESCRIPTION.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EXPENSE__EXPENSE__DESCRIPTION.props"
											@blur="onBlur(controls.EXPENSE__EXPENSE__DESCRIPTION, model.ValDescription.value)"
											@change="model.ValDescription.fnUpdateValueOnChange" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__INVOICE.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__INVOICE"
										v-on="controls.EXPENSE__EXPENSE__INVOICE.handlers"
										:loading="controls.EXPENSE__EXPENSE__INVOICE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-document
											v-if="controls.EXPENSE__EXPENSE__INVOICE.isVisible"
											v-bind="controls.EXPENSE__EXPENSE__INVOICE.props"
											v-on="controls.EXPENSE__EXPENSE__INVOICE.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End EXPENSE_PSEUDNEWGRP02 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.EXPENSE_PSEUDNEWGRP01.isVisible">
					<q-col v-if="controls.EXPENSE_PSEUDNEWGRP01.isVisible">
						<q-group-box-container
							v-if="controls.EXPENSE_PSEUDNEWGRP01.isVisible"
							id="EXPENSE_PSEUDNEWGRP01"
							v-bind="controls.EXPENSE_PSEUDNEWGRP01"
							:is-visible="controls.EXPENSE_PSEUDNEWGRP01.isVisible">
							<!-- Start EXPENSE_PSEUDNEWGRP01 -->
							<q-row v-if="controls.EXPENSE__EXPENSE__CREATED_BY.isVisible || controls.EXPENSE__EXPENSE__CREATED_AT.isVisible">
								<q-col
									v-if="controls.EXPENSE__EXPENSE__CREATED_BY.isVisible || controls.EXPENSE__EXPENSE__CREATED_AT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__CREATED_BY.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__CREATED_BY"
										v-on="controls.EXPENSE__EXPENSE__CREATED_BY.handlers"
										:loading="controls.EXPENSE__EXPENSE__CREATED_BY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EXPENSE__EXPENSE__CREATED_BY.props"
											@blur="onBlur(controls.EXPENSE__EXPENSE__CREATED_BY, model.ValCreated_by.value)"
											@change="model.ValCreated_by.fnUpdateValueOnChange" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__CREATED_AT.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__CREATED_AT"
										v-on="controls.EXPENSE__EXPENSE__CREATED_AT.handlers"
										:loading="controls.EXPENSE__EXPENSE__CREATED_AT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.EXPENSE__EXPENSE__CREATED_AT.isVisible"
											v-bind="controls.EXPENSE__EXPENSE__CREATED_AT.props"
											:model-value="model.ValCreated_at.value"
											@reset-icon-click="model.ValCreated_at.fnUpdateValue(model.ValCreated_at.originalValue ?? new Date())"
											@update:model-value="model.ValCreated_at.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.EXPENSE__EXPENSE__UPDATED_BY.isVisible || controls.EXPENSE__EXPENSE__UPDATED_AT.isVisible">
								<q-col
									v-if="controls.EXPENSE__EXPENSE__UPDATED_BY.isVisible || controls.EXPENSE__EXPENSE__UPDATED_AT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__UPDATED_BY.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__UPDATED_BY"
										v-on="controls.EXPENSE__EXPENSE__UPDATED_BY.handlers"
										:loading="controls.EXPENSE__EXPENSE__UPDATED_BY.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.EXPENSE__EXPENSE__UPDATED_BY.props"
											@blur="onBlur(controls.EXPENSE__EXPENSE__UPDATED_BY, model.ValUpdated_by.value)"
											@change="model.ValUpdated_by.fnUpdateValueOnChange" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.EXPENSE__EXPENSE__UPDATED_AT.isVisible"
										class="i-text"
										v-bind="controls.EXPENSE__EXPENSE__UPDATED_AT"
										v-on="controls.EXPENSE__EXPENSE__UPDATED_AT.handlers"
										:loading="controls.EXPENSE__EXPENSE__UPDATED_AT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.EXPENSE__EXPENSE__UPDATED_AT.isVisible"
											v-bind="controls.EXPENSE__EXPENSE__UPDATED_AT.props"
											:model-value="model.ValUpdated_at.value"
											@reset-icon-click="model.ValUpdated_at.fnUpdateValue(model.ValUpdated_at.originalValue ?? new Date())"
											@update:model-value="model.ValUpdated_at.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End EXPENSE_PSEUDNEWGRP01 -->
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

	import FormViewModel from './QFormExpenseViewModel.js'

	const requiredTextResources = ['QFormExpense', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FORM_INCLUDEJS EXPENSE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormExpense',

		components: {
			QSeeMoreExpenseCategoryTypeName: defineAsyncComponent(() => import('@/views/forms/FormExpense/dbedits/ExpenseCategoryTypeNameSeeMore.vue')),
			QSeeMoreExpenseCategoryName: defineAsyncComponent(() => import('@/views/forms/FormExpense/dbedits/ExpenseCategoryNameSeeMore.vue')),
			QSeeMoreExpenseMemberName: defineAsyncComponent(() => import('@/views/forms/FormExpense/dbedits/ExpenseMemberNameSeeMore.vue')),
			QSeeMoreExpenseSourceTitle: defineAsyncComponent(() => import('@/views/forms/FormExpense/dbedits/ExpenseSourceTitleSeeMore.vue')),
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
					name: 'EXPENSE',
					location: 'form-EXPENSE',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormExpense', false),

				interfaceMetadata: {
					id: 'QFormExpense', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'popup',
					name: 'EXPENSE',
					route: 'form-EXPENSE',
					area: 'EXPENSE',
					primaryKey: 'ValCodexpense',
					designation: computed(() => this.Resources.EXPENSE49437),
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
					EXPENSE__EXPENSE__EXPENSE_ID: new fieldControlClass.NumberControl({
						modelField: 'ValExpense_id',
						valueChangeEvent: 'fieldChange:expense.expense_id',
						id: 'EXPENSE__EXPENSE__EXPENSE_ID',
						name: 'EXPENSE_ID',
						size: 'medium',
						label: computed(() => this.Resources.ID48520),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 6,
						maxDecimals: 0,
						isSequencial: true,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EXPENSE_PSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'EXPENSE_PSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.INFO27076),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['EXPENSE__CATEGORY_TYPE__NAME', 'EXPENSE__CATEGORY__NAME', 'EXPENSE__MEMBER__NAME', 'EXPENSE_GROUPNAME____', 'EXPENSE__SOURCE__TITLE', 'EXPENSE__EXPENSE__VALUE', 'EXPENSE__EXPENSE__DATE', 'EXPENSE__EXPENSE__MONTH', 'EXPENSE__EXPENSE__YEAR', 'EXPENSE__EXPENSE__DESCRIPTION', 'EXPENSE__EXPENSE__INVOICE'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EXPENSE__CATEGORY_TYPE__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableCategory_typeName',
						valueChangeEvent: 'fieldChange:category_type.name',
						id: 'EXPENSE__CATEGORY_TYPE__NAME',
						name: 'NAME',
						size: 'large',
						label: computed(() => this.Resources.CATEGORY_TYPE34342),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValType_id',
							dependencyEvent: 'fieldChange:expense.type_id'
						},
						dependentFields: () => ({
							set 'category_type.codcategory_type'(value) { vm.model.ValType_id.updateValue(value) },
							set 'category_type.name'(value) { vm.model.TableCategory_typeName.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EXPENSE__CATEGORY__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableCategoryName',
						valueChangeEvent: 'fieldChange:category.name',
						id: 'EXPENSE__CATEGORY__NAME',
						name: 'NAME',
						size: 'large',
						label: computed(() => this.Resources.CATEGORY18978),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCategory_id',
							dependencyEvent: 'fieldChange:expense.category_id'
						},
						dependentFields: () => ({
							set 'category.codcategory'(value) { vm.model.ValCategory_id.updateValue(value) },
							set 'category.name'(value) { vm.model.TableCategoryName.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
							{
								identifier: ['category_type', 'expense.type_id'],
								dependencyEvents: ['fieldChange:expense.type_id'],
								dependencyField: 'EXPENSE.TYPE_ID',
								fnValueSelector: (model) => model.ValType_id.value
							},
						],
					}, this),
					EXPENSE__MEMBER__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableMemberName',
						valueChangeEvent: 'fieldChange:member.name',
						id: 'EXPENSE__MEMBER__NAME',
						name: 'NAME',
						size: 'large',
						label: computed(() => this.Resources.MEMBER00534),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
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
							dependencyEvent: 'fieldChange:expense.member_id'
						},
						dependentFields: () => ({
							set 'member.codmember'(value) { vm.model.ValMember_id.updateValue(value) },
							set 'member.name'(value) { vm.model.TableMemberName.updateValue(value) },
							set 'expense.group_id'(value) { vm.model.ValGroup_id.updateValue(value) },
							set 'group.codgroup'(value) { vm.model.ValGroup_id.updateValue(value) },
							set 'group.name'(value) { vm.model.GroupValName.updateValue(value) },
						}),
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EXPENSE_GROUPNAME____: new fieldControlClass.StringControl({
						modelField: 'GroupValName',
						valueChangeEvent: 'fieldChange:group.name',
						dependentModelField: 'ValGroup_id',
						dependentChangeEvent: 'fieldChange:expense.group_id',
						id: 'EXPENSE_GROUPNAME____',
						name: 'NAME',
						size: 'large',
						label: computed(() => this.Resources.GROUP38232),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						maxLength: 50,
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line @typescript-eslint/no-unused-vars
							fnFormula(params)
							{
								// Formula: !isEmptyC([MEMBER->NAME])
								return !(this.TableMemberName.value === '')
							},
							dependencyEvents: ['fieldChange:member.name'],
							isServerRecalc: false,
						},
					}, this),
					EXPENSE__SOURCE__TITLE: new fieldControlClass.LookupControl({
						modelField: 'TableSourceTitle',
						valueChangeEvent: 'fieldChange:source.title',
						id: 'EXPENSE__SOURCE__TITLE',
						name: 'TITLE',
						size: 'large',
						label: computed(() => this.Resources.ACCOUNT64260),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValSource_id',
							dependencyEvent: 'fieldChange:expense.source_id'
						},
						dependentFields: () => ({
							set 'source.codsource'(value) { vm.model.ValSource_id.updateValue(value) },
							set 'source.title'(value) { vm.model.TableSourceTitle.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__VALUE: new fieldControlClass.CurrencyControl({
						modelField: 'ValValue',
						valueChangeEvent: 'fieldChange:expense.value',
						id: 'EXPENSE__EXPENSE__VALUE',
						name: 'VALUE',
						size: 'small',
						label: computed(() => this.Resources.VALUE10285),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						maxIntegers: 9,
						maxDecimals: 2,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__DATE: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:expense.date',
						id: 'EXPENSE__EXPENSE__DATE',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.DATE18475),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						dateTimeType: 'date',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__MONTH: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValMonth',
						valueChangeEvent: 'fieldChange:expense.month',
						id: 'EXPENSE__EXPENSE__MONTH',
						name: 'MONTH',
						size: 'small',
						label: computed(() => this.Resources.MONTH46035),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						isFormulaBlocked: true,
						maxIntegers: 2,
						maxDecimals: 0,
						arrayName: 'Month',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__YEAR: new fieldControlClass.ArrayNumberControl({
						modelField: 'ValYear',
						valueChangeEvent: 'fieldChange:expense.year',
						id: 'EXPENSE__EXPENSE__YEAR',
						name: 'YEAR',
						size: 'small',
						label: computed(() => this.Resources.YEAR61794),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						isFormulaBlocked: true,
						maxIntegers: 4,
						maxDecimals: 0,
						arrayName: 'Year',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__DESCRIPTION: new fieldControlClass.StringControl({
						modelField: 'ValDescription',
						valueChangeEvent: 'fieldChange:expense.description',
						id: 'EXPENSE__EXPENSE__DESCRIPTION',
						name: 'DESCRIPTION',
						size: 'xlarge',
						label: computed(() => this.Resources.DESCRIPTION07383),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						maxLength: 200,
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__INVOICE: new fieldControlClass.DocumentControl({
						modelField: 'ValInvoice',
						valueChangeEvent: 'fieldChange:expense.invoice',
						id: 'EXPENSE__EXPENSE__INVOICE',
						name: 'INVOICE',
						size: 'small',
						label: computed(() => this.Resources.INVOICE63068),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP02',
						extensions: [],
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					EXPENSE_PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'EXPENSE_PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.CONTROL15481),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['EXPENSE__EXPENSE__CREATED_BY', 'EXPENSE__EXPENSE__CREATED_AT', 'EXPENSE__EXPENSE__UPDATED_BY', 'EXPENSE__EXPENSE__UPDATED_AT'],
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__CREATED_BY: new fieldControlClass.StringControl({
						modelField: 'ValCreated_by',
						valueChangeEvent: 'fieldChange:expense.created_by',
						id: 'EXPENSE__EXPENSE__CREATED_BY',
						name: 'CREATED_BY',
						size: 'large',
						label: computed(() => this.Resources.CREATED_BY58035),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP01',
						maxLength: 100,
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__CREATED_AT: new fieldControlClass.DateControl({
						modelField: 'ValCreated_at',
						valueChangeEvent: 'fieldChange:expense.created_at',
						id: 'EXPENSE__EXPENSE__CREATED_AT',
						name: 'CREATED_AT',
						size: 'large',
						label: computed(() => this.Resources.CREATED_AT09073),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP01',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__UPDATED_BY: new fieldControlClass.StringControl({
						modelField: 'ValUpdated_by',
						valueChangeEvent: 'fieldChange:expense.updated_by',
						id: 'EXPENSE__EXPENSE__UPDATED_BY',
						name: 'UPDATED_BY',
						size: 'large',
						label: computed(() => this.Resources.UPDATED_BY38656),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP01',
						maxLength: 100,
						controlLimits: [
						],
					}, this),
					EXPENSE__EXPENSE__UPDATED_AT: new fieldControlClass.DateControl({
						modelField: 'ValUpdated_at',
						valueChangeEvent: 'fieldChange:expense.updated_at',
						id: 'EXPENSE__EXPENSE__UPDATED_AT',
						name: 'UPDATED_AT',
						size: 'large',
						label: computed(() => this.Resources.UPDATED_AT48366),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'EXPENSE_PSEUDNEWGRP01',
						dateTimeType: 'date',
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
					'EXPENSE_PSEUDNEWGRP02',
					'EXPENSE_PSEUDNEWGRP01',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Category: {
						get ValName() { return vm.model.TableCategoryName.value },
						set ValName(value) { vm.model.TableCategoryName.updateValue(value) },
					},
					Category_type: {
						get ValName() { return vm.model.TableCategory_typeName.value },
						set ValName(value) { vm.model.TableCategory_typeName.updateValue(value) },
					},
					Expense: {
						get ValCategory_id() { return vm.model.ValCategory_id.value },
						set ValCategory_id(value) { vm.model.ValCategory_id.updateValue(value) },
						get ValCreated_at() { return vm.model.ValCreated_at.value },
						set ValCreated_at(value) { vm.model.ValCreated_at.updateValue(value) },
						get ValCreated_by() { return vm.model.ValCreated_by.value },
						set ValCreated_by(value) { vm.model.ValCreated_by.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValDescription() { return vm.model.ValDescription.value },
						set ValDescription(value) { vm.model.ValDescription.updateValue(value) },
						get ValExpense_id() { return vm.model.ValExpense_id.value },
						set ValExpense_id(value) { vm.model.ValExpense_id.updateValue(value) },
						get ValGroup_id() { return vm.model.ValGroup_id.value },
						set ValGroup_id(value) { vm.model.ValGroup_id.updateValue(value) },
						get ValInvoice() { return vm.model.ValInvoice.value },
						set ValInvoice(value) { vm.model.ValInvoice.updateValue(value) },
						get ValMember_id() { return vm.model.ValMember_id.value },
						set ValMember_id(value) { vm.model.ValMember_id.updateValue(value) },
						get ValMonth() { return vm.model.ValMonth.value },
						set ValMonth(value) { vm.model.ValMonth.updateValue(value) },
						get ValMonth_fk() { return vm.model.ValMonth_fk.value },
						set ValMonth_fk(value) { vm.model.ValMonth_fk.updateValue(value) },
						get ValSource_id() { return vm.model.ValSource_id.value },
						set ValSource_id(value) { vm.model.ValSource_id.updateValue(value) },
						get ValType_id() { return vm.model.ValType_id.value },
						set ValType_id(value) { vm.model.ValType_id.updateValue(value) },
						get ValUpdated_at() { return vm.model.ValUpdated_at.value },
						set ValUpdated_at(value) { vm.model.ValUpdated_at.updateValue(value) },
						get ValUpdated_by() { return vm.model.ValUpdated_by.value },
						set ValUpdated_by(value) { vm.model.ValUpdated_by.updateValue(value) },
						get ValValue() { return vm.model.ValValue.value },
						set ValValue(value) { vm.model.ValValue.updateValue(value) },
						get ValYear() { return vm.model.ValYear.value },
						set ValYear(value) { vm.model.ValYear.updateValue(value) },
					},
					Group: {
						get ValName() { return vm.model.GroupValName.value },
						set ValName(value) { vm.model.GroupValName.updateValue(value) },
					},
					Member: {
						get ValName() { return vm.model.TableMemberName.value },
						set ValName(value) { vm.model.TableMemberName.updateValue(value) },
					},
					Source: {
						get ValTitle() { return vm.model.TableSourceTitle.value },
						set ValTitle(value) { vm.model.TableSourceTitle.updateValue(value) },
					},
					keys: {
						/** The primary key of the EXPENSE table */
						get expense() { return vm.model.ValCodexpense },
						/** The foreign key to the CATEGORY table */
						get category() { return vm.model.ValCategory_id },
						/** The foreign key to the MEMBER table */
						get member() { return vm.model.ValMember_id },
						/** The foreign key to the SOURCE table */
						get source() { return vm.model.ValSource_id },
						/** The foreign key to the CATEGORY_TYPE table */
						get category_type() { return vm.model.ValType_id },
						/** The foreign key to the GROUP table */
						get group() { return vm.model.ValGroup_id },
						/** The foreign key to the MONTH table */
						get month() { return vm.model.ValMonth_fk },
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
// USE /[MANUAL MNT FORM_CODEJS EXPENSE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT COMPONENT_BEFORE_UNMOUNT EXPENSE]/
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
// USE /[MANUAL MNT BEFORE_LOAD_JS EXPENSE]/
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
// USE /[MANUAL MNT FORM_LOADED_JS EXPENSE]/
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
// USE /[MANUAL MNT BEFORE_APPLY_JS EXPENSE]/
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
// USE /[MANUAL MNT AFTER_APPLY_JS EXPENSE]/
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
// USE /[MANUAL MNT BEFORE_SAVE_JS EXPENSE]/
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
// USE /[MANUAL MNT AFTER_SAVE_JS EXPENSE]/
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
// USE /[MANUAL MNT BEFORE_DEL_JS EXPENSE]/
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
// USE /[MANUAL MNT AFTER_DEL_JS EXPENSE]/
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
// USE /[MANUAL MNT BEFORE_EXIT_JS EXPENSE]/
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
// USE /[MANUAL MNT AFTER_EXIT_JS EXPENSE]/
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
// USE /[MANUAL MNT DLGUPDT EXPENSE]/
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
// USE /[MANUAL MNT CTRLBLR EXPENSE]/
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
// USE /[MANUAL MNT CTRLUPD EXPENSE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FUNCTIONS_JS EXPENSE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
