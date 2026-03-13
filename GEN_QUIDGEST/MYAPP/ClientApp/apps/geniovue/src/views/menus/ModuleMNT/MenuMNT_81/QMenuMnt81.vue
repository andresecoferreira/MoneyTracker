<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-bind="controls.menu"
					v-on="controls.menu.handlers">
					<template #header>
						<q-table-config
							:table-ctrl="controls.menu"
							v-on="controls.menu.handlers" />
					</template>
					<!-- USE /[MANUAL MNT CUSTOM_TABLE MNT_Menu_81]/ -->
				</q-table>
			</q-row-container>
		</form>
	</teleport>

	<teleport
		v-if="menuModalIsReady && hasButtons"
		:to="`#${uiContainersId.footer}`"
		:disabled="!menuInfo.isPopup">
		<q-row-container>
			<div id="footer-action-btns">
				<template
					v-for="btn in menuButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isVisible"
						:id="btn.id"
						:label="btn.text"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import netAPI from '@quidgest/clientapp/network'
	import openQSign from '@quidgest/clientapp/plugins/qSign'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import { computed, readonly } from 'vue'

	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import { loadResources } from '@/plugins/i18n.js'

	import hardcodedTexts from '@/hardcodedTexts'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import MenuViewModel from './QMenuMNT_81ViewModel.js'

	const requiredTextResources = ['QMenuMNT_81', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FORM_INCLUDEJS MNT_MENU_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuMnt81',

		mixins: [
			MenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the menu is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'onBeforeRouteLeave',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuMNT_81', false),

				interfaceMetadata: {
					id: 'QMenuMNT_81', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '81',
					isMenuList: true,
					designation: computed(() => this.Resources.MEMBERS31628),
					acronym: 'MNT_81',
					name: 'MEMBER',
					route: 'menu-MNT_81',
					order: '81',
					controller: 'MEMBER',
					action: 'MNT_Menu_81',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'MNT_Menu_81',
						controller: 'MEMBER',
						action: 'MNT_Menu_81',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
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
							new listColumnTypes.CurrencyColumn({
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
							new listColumnTypes.CurrencyColumn({
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
							new listColumnTypes.CurrencyColumn({
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
							new listColumnTypes.CurrencyColumn({
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
							name: 'MNT_Menu_81',
							serverMode: true,
							pkColumn: 'ValCodmember',
							tableAlias: 'MEMBER',
							tableNamePlural: computed(() => this.Resources.MEMBERS31628),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.MEMBERS31628),
							showAlternatePagination: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							searchBarConfig: {
								visibility: true
							},
							allowColumnFilters: true,
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
						uuid: '023c4ea4-bc76-43d4-aa36-5fe38248c78e',
						allSelectedRows: 'false',
						headerLevel: 1,
						isActiveControl: computed(() => this.isActiveMenu)
					}, this),
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		beforeRouteLeave(to, _, next)
		{
			this.onBeforeRouteLeave(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FORM_CODEJS MNT_MENU_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT COMPONENT_BEFORE_UNMOUNT MNT_MENU_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT FUNCTIONS_JS MNT_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL MNT LISTING_CODEJS MNT_MENU_81]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
