// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/MNT/menu/MNT_131',
			name: 'menu-MNT_131',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_131/QMenuMnt131.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '131',
				baseArea: 'GROUP_PSW',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_121',
			name: 'menu-MNT_121',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_121/QMenuMnt121.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '121',
				baseArea: 'CATEGORY_TYPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_111',
			name: 'menu-MNT_111',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_111/QMenuMnt111.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '111',
				baseArea: 'GROUP',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_31',
			name: 'menu-MNT_31',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_31/QMenuMnt31.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '31',
				baseArea: 'GROUP',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_1111',
			name: 'menu-MNT_1111',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_1111/QMenuMnt1111.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '1111',
				baseArea: 'MEMBER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['group' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_311',
			name: 'menu-MNT_311',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_311/QMenuMnt311.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '311',
				baseArea: 'MEMBER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['group' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_81',
			name: 'menu-MNT_81',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_81/QMenuMnt81.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '81',
				baseArea: 'MEMBER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_411',
			name: 'menu-MNT_411',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_411/QMenuMnt411.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '411',
				baseArea: 'EXPENSE',
				hasInitialPHE: false,
				humanKeyFields: ['ValExpense_id'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_1211',
			name: 'menu-MNT_1211',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_1211/QMenuMnt1211.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '1211',
				baseArea: 'CATEGORY',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['category_type' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_421',
			name: 'menu-MNT_421',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_421/QMenuMnt421.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '421',
				baseArea: 'INCOME',
				hasInitialPHE: false,
				humanKeyFields: ['ValIncome_id'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_431',
			name: 'menu-MNT_431',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_431/QMenuMnt431.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '431',
				baseArea: 'INVESTMENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValInvestment_id'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_21',
			name: 'menu-MNT_21',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_21/QMenuMnt21.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '21',
				baseArea: 'Dashboard',
				isDashboardPage: true,
				hasInitialPHE: false,
				isPopup: false
			}
		},
	]
}
