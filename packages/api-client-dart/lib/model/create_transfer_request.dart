//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/transfer_line_write_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'create_transfer_request.g.dart';

abstract class CreateTransferRequest implements Built<CreateTransferRequest, CreateTransferRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'sourceStoreId')
    String get sourceStoreId;

    @BuiltValueField(wireName: r'targetStoreId')
    String get targetStoreId;

    @BuiltValueField(wireName: r'lines')
    BuiltList<TransferLineWriteDto> get lines;

    CreateTransferRequest._();

    static void _initializeBuilder(CreateTransferRequestBuilder b) => b;

    factory CreateTransferRequest([void updates(CreateTransferRequestBuilder b)]) = _$CreateTransferRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<CreateTransferRequest> get serializer => _$CreateTransferRequestSerializer();
}

class _$CreateTransferRequestSerializer implements StructuredSerializer<CreateTransferRequest> {

    @override
    final Iterable<Type> types = const [CreateTransferRequest, _$CreateTransferRequest];
    @override
    final String wireName = r'CreateTransferRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, CreateTransferRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'sourceStoreId')
            ..add(serializers.serialize(object.sourceStoreId,
                specifiedType: const FullType(String)));
        result
            ..add(r'targetStoreId')
            ..add(serializers.serialize(object.targetStoreId,
                specifiedType: const FullType(String)));
        result
            ..add(r'lines')
            ..add(serializers.serialize(object.lines,
                specifiedType: const FullType(BuiltList, [FullType(TransferLineWriteDto)])));
        return result;
    }

    @override
    CreateTransferRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CreateTransferRequestBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'sourceStoreId':
                    result.sourceStoreId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'targetStoreId':
                    result.targetStoreId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'lines':
                    result.lines.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(TransferLineWriteDto)])) as BuiltList<TransferLineWriteDto>);
                    break;
            }
        }
        return result.build();
    }
}

