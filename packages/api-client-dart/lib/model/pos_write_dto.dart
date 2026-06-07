//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'pos_write_dto.g.dart';

abstract class PosWriteDto implements Built<PosWriteDto, PosWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'branchId')
    String get branchId;

    @BuiltValueField(wireName: r'storeId')
    String get storeId;

    PosWriteDto._();

    static void _initializeBuilder(PosWriteDtoBuilder b) => b;

    factory PosWriteDto([void updates(PosWriteDtoBuilder b)]) = _$PosWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PosWriteDto> get serializer => _$PosWriteDtoSerializer();
}

class _$PosWriteDtoSerializer implements StructuredSerializer<PosWriteDto> {

    @override
    final Iterable<Type> types = const [PosWriteDto, _$PosWriteDto];
    @override
    final String wireName = r'PosWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PosWriteDto object,
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
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'branchId')
            ..add(serializers.serialize(object.branchId,
                specifiedType: const FullType(String)));
        result
            ..add(r'storeId')
            ..add(serializers.serialize(object.storeId,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    PosWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PosWriteDtoBuilder();

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
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'branchId':
                    result.branchId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'storeId':
                    result.storeId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

