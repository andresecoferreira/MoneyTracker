<template>
	<div
		v-if="!componentOnLoadProc.loaded"
		class="q-widget__overlay">
		<q-spinner-loader />
	</div>
	<template v-else>
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

		<q-container
			fluid
			data-key="WD_EXPENSES"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.WD_EXPENSES__PSEUD__FIELD001.isVisible">
					<q-col v-if="controls.WD_EXPENSES__PSEUD__FIELD001.isVisible">
						<q-table
							v-if="controls.WD_EXPENSES__PSEUD__FIELD001.isVisible"
							v-bind="controls.WD_EXPENSES__PSEUD__FIELD001"
							v-on="controls.WD_EXPENSES__PSEUD__FIELD001.handlers">
							<template #header>
								<q-table-config
									:table-ctrl="controls.WD_EXPENSES__PSEUD__FIELD001"
									v-on="controls.WD_EXPENSES__PSEUD__FIELD001.handlers" />
							</template>
							<!-- USE /[MANUAL MNT CUSTOM_TABLE WD_EXPENSES__PSEUD__FIELD001]/ -->
						</q-table>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</template>
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

	import FormViewModel from './QFormWdExpensesViewModel.js'

	const requiredTextResources = ['QFormWdExpenses', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FORM_INCLUDEJS WD_EXPENSES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormWdExpenses',

		components: {
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
					name: 'WD_EXPENSES',
					location: 'form-WD_EXPENSES',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormWdExpenses', false),

				interfaceMetadata: {
					id: 'QFormWdExpenses', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'widget',
					name: 'WD_EXPENSES',
					route: 'form-WD_EXPENSES',
					area: 'EXPENSE',
					primaryKey: 'ValCodexpense',
					designation: '',
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
					WD_EXPENSES__PSEUD__FIELD001: new fieldControlClass.TableSpecialRenderingControl({
						id: 'WD_EXPENSES__PSEUD__FIELD001',
						name: 'FIELD001',
						size: 'block',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'EXPENSE',
						action: 'Wd_expenses_ValField001',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'MEMBER',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 80,
								scrollData: 20,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValIncome',
								area: 'MEMBER',
								field: 'INCOME',
								label: computed(() => this.Resources.INCOME04695),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
								totalizer: true,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValExpenses',
								area: 'MEMBER',
								field: 'EXPENSES',
								label: computed(() => this.Resources.EXPENSES11381),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
								totalizer: true,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValInvestment',
								area: 'MEMBER',
								field: 'INVESTMENT',
								label: computed(() => this.Resources.INVESTMENT14761),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
								totalizer: true,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValResult',
								area: 'MEMBER',
								field: 'RESULT',
								label: computed(() => this.Resources.RESULT40974),
								scrollData: 12,
								maxDigits: 9,
								decimalPlaces: 2,
								totalizer: true,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValField001',
							serverMode: true,
							pkColumn: 'ValCodmember',
							tableAlias: 'MEMBER',
							tableNamePlural: computed(() => this.Resources.MEMBERS31628),
							viewManagement: '',
							showLimitsInfo: true,
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							allowColumnFilters: false,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-MEMBER', 'changed-GROUP'],
						uuid: 'Wd_expenses_ValField001',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'CHART',
								type: 'chart',
								subtype: 'genericgraph',
								label: computed(() => this.Resources.GRAFICO38823),
								order: 1,
								mappingVariables: readonly({
									xaxis: {
										allowsMultiple: false,
										sources: [
											'MEMBER.NAME',
										]
									},
									yaxis: {
										allowsMultiple: true,
										sources: [
											'MEMBER.INCOME',
											'MEMBER.EXPENSES',
											'MEMBER.INVESTMENT',
										]
									},
								}),
								styleVariables: {
									chartType: {
										rawValue: 'column',
										isMapped: false
									},
									firstColor: {
										rawValue: 'undefined',
										isMapped: false
									},
									chartColorArray: {
										rawValue: 'Highcharts Default',
										isMapped: false
									},
									invertColorArray: {
										rawValue: false,
										isMapped: false
									},
									xaxisType: {
										rawValue: 'linear',
										isMapped: false
									},
									yaxisType: {
										rawValue: 'linear',
										isMapped: false
									},
									graphTitle: {
										rawValue: 'Financial Summary by Member',
										isMapped: false
									},
									description: {
										rawValue: undefined,
										isMapped: false
									},
									alignDescription: {
										rawValue: 'left',
										isMapped: false
									},
									yaxisName: {
										rawValue: undefined,
										isMapped: false
									},
									xaxisName: {
										rawValue: undefined,
										isMapped: false
									},
									groupType: {
										rawValue: 'join',
										isMapped: false
									},
									inverted: {
										rawValue: false,
										isMapped: false
									},
									showLabels: {
										rawValue: true,
										isMapped: false
									},
									showLegend: {
										rawValue: true,
										isMapped: false
									},
									widthPercentage: {
										rawValue: 100,
										isMapped: false
									},
									showPieLabel: {
										rawValue: 'outside',
										isMapped: false
									},
									lineMarker: {
										rawValue: 'enabled',
										isMapped: false
									},
									heightPx: {
										rawValue: 400,
										isMapped: false
									},
									pieInnerSizePercentage: {
										rawValue: 0,
										isMapped: false
									},
									showBreaks: {
										rawValue: false,
										isMapped: false
									},
									enableHover: {
										rawValue: true,
										isMapped: false
									},
									zoomType: {
										rawValue: 'x',
										isMapped: false
									},
									legendLayout: {
										rawValue: 'horizontal',
										isMapped: false
									},
									legendXPosition: {
										rawValue: 0,
										isMapped: false
									},
									showLastN: {
										rawValue: -1,
										isMapped: false
									},
									legendYPosition: {
										rawValue: 0,
										isMapped: false
									},
									legendFloating: {
										rawValue: false,
										isMapped: false
									},
									legendAlign: {
										rawValue: 'center',
										isMapped: false
									},
									legendVerticalAlign: {
										rawValue: 'top',
										isMapped: false
									},
									stackingType: {
										rawValue: 'undefined',
										isMapped: false
									},
									valuesDecimals: {
										rawValue: 0,
										isMapped: false
									},
								},
								groups: {
								}
							},
							{
								id: 'LIST',
								type: 'list',
								subtype: '',
								label: computed(() => this.Resources.LISTA13474),
								order: 2,
								mappingVariables: readonly({
								}),
								styleVariables: {
								},
								groups: {
								}
							},
						],
						controlLimits: [
							{
								identifier: ['id', 'expense'],
								dependencyEvents: ['fieldChange:expense.codexpense'],
								dependencyField: 'EXPENSE.CODEXPENSE',
								fnValueSelector: (model) => model.ValCodexpense.value
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
				]),

				tableFields: readonly([
					'WD_EXPENSES__PSEUD__FIELD001',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Expense: {
						get ValCategory_id() { return vm.model.ValCategory_id.value },
						set ValCategory_id(value) { vm.model.ValCategory_id.updateValue(value) },
						get ValExpense_id() { return vm.model.ValExpense_id.value },
						set ValExpense_id(value) { vm.model.ValExpense_id.updateValue(value) },
						get ValGroup_id() { return vm.model.ValGroup_id.value },
						set ValGroup_id(value) { vm.model.ValGroup_id.updateValue(value) },
						get ValMember_id() { return vm.model.ValMember_id.value },
						set ValMember_id(value) { vm.model.ValMember_id.updateValue(value) },
						get ValMonth_fk() { return vm.model.ValMonth_fk.value },
						set ValMonth_fk(value) { vm.model.ValMonth_fk.updateValue(value) },
						get ValSource_id() { return vm.model.ValSource_id.value },
						set ValSource_id(value) { vm.model.ValSource_id.updateValue(value) },
						get ValType_id() { return vm.model.ValType_id.value },
						set ValType_id(value) { vm.model.ValType_id.updateValue(value) },
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
// USE /[MANUAL MNT FORM_CODEJS WD_EXPENSES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT COMPONENT_BEFORE_UNMOUNT WD_EXPENSES]/
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
// USE /[MANUAL MNT BEFORE_LOAD_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT FORM_LOADED_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT BEFORE_APPLY_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT AFTER_APPLY_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT BEFORE_SAVE_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT AFTER_SAVE_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT BEFORE_DEL_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT AFTER_DEL_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT BEFORE_EXIT_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT AFTER_EXIT_JS WD_EXPENSES]/
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
// USE /[MANUAL MNT DLGUPDT WD_EXPENSES]/
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
// USE /[MANUAL MNT CTRLBLR WD_EXPENSES]/
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
// USE /[MANUAL MNT CTRLUPD WD_EXPENSES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FUNCTIONS_JS WD_EXPENSES]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
