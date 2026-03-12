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
			path: '/:culture/:system/MNT/menu/MNT_21',
			name: 'menu-MNT_21',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_21/QMenuMnt21.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '21',
				baseArea: 'SOURCE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
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
			path: '/:culture/:system/MNT/menu/MNT_41',
			name: 'menu-MNT_41',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_41/QMenuMnt41.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '41',
				baseArea: 'MEMBER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_311',
			name: 'menu-MNT_311',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_311/QMenuMnt311.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '311',
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
			path: '/:culture/:system/MNT/menu/MNT_321',
			name: 'menu-MNT_321',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_321/QMenuMnt321.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '321',
				baseArea: 'INCOME',
				hasInitialPHE: false,
				humanKeyFields: ['ValIncome_id'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_331',
			name: 'menu-MNT_331',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_331/QMenuMnt331.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '331',
				baseArea: 'INVESTMENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValInvestment_id'],
				isPopup: false
			}
		},
	]
}
