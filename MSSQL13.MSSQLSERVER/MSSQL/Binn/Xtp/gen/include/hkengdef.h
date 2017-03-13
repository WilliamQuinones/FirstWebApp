//*********************************************************************
// Copyright (c) Microsoft Corporation.
//*********************************************************************



















#pragma once

struct HkTransaction;
struct HkTxDeltaTracker;
struct HkErrorObject;
struct HkRow;
struct HkParam;
struct HkCallbackContext;
struct HkCursorHash;
struct HkCursorRange;
struct HkCursorHashParent;
struct HkCursorDeltaTracker;
struct HkLockBytes;







struct HkSearchKey;
struct HkFlatKey;











typedef enum
{
	isoReadUncommitted,
	isoSnapshot,
	isoReadRepeatable,
	isoSerializable,

} TxIsoLevel;



struct HkInt128
{
	
	__int64	val[2];
};




struct HkInt256
{
	
	__int64	val[4];
};



struct HkInt320
{
	
	__int64 val[5];
};













struct HkInt192
{
	__int64 val[3];
};



typedef unsigned long HkTxSavePointId;



const HkTxSavePointId HkTxSavePointDefault = 0;





























typedef unsigned int HkTableId;



typedef __int64 HkLobId;



#if !defined(HKEAPI)
	#if defined(HKENGINE_BUILD)
		#define HKEAPI extern "C" __declspec(dllexport)
	#else
		#if defined(__cplusplus)
			#define HKEAPI extern "C" __declspec(dllimport)
		#else
			#define HKEAPI __declspec(dllimport)
		#endif
	#endif
#endif





#if !defined(HKAPICC)
	#if defined(_X86_)
		#define HKAPICC __cdecl
	#else
		#define HKAPICC
	#endif
#endif

HKEAPI __checkReturn const struct TxStatusStruct* HKAPICC
HkTransactionGetStatus(
	__in struct HkTransaction* tx);

HKEAPI void HKAPICC
HkTransactionDeltaTrackerSetEnd(
	__inout struct HkTxDeltaTracker* tracker);



typedef __callback void
(*TxRundownCallbackFn)(
	__inout struct TxStatusStruct* status,
	__in struct HkTransaction* tx);



typedef __callback void
(*TxCommitCallbackFn)(
	__in const struct TxStatusStruct* status,
	__in void* data);

typedef __checkReturn HRESULT
(*FilterFn)(
	__in const struct HkParam* params,
	__in const struct HkRow* row,
	__in struct HkCallbackContext* context);

